using System.Drawing;

namespace GbColouriser
{
    public class ImageColouriser
    {
        private readonly RecolouredImage _recolouredImage;

        // probably need to work out then create a new colour information object that encompasses all those dictionaries

        private Color GBWhite => Color.FromArgb(224, 248, 207);
        private Color GBLight => Color.FromArgb(134, 192, 108);
        private Color GBDark => Color.FromArgb(48, 104, 80);
        private Color GBBlack => Color.FromArgb(7, 24, 33);

        public ImageColouriser(Image image)
        {
            _recolouredImage = new RecolouredImage(image);
        }

        public ITile[,] Process()
        {
            RecolourBasedOnFourColourTiles(_recolouredImage);

            // imagine actually writing this horror of a linq statement
            var mostUsedGbColoursPerRealColourDictionary = _recolouredImage.TileColourDictionary
                .SelectMany(x => x.Value)
                .OrderByDescending(x => x.Key.GetPerceivedBrightness())
                .GroupBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.GroupBy(x => x.Value).OrderByDescending(x => x.Key).First().First().Value);

            var unfinishedTiles = _recolouredImage.Tiles.ToIEnumerable().Where(x => !x.IsFullyRecoloured).ToList();
            RecolourBasedOnTransparentTiles(unfinishedTiles);

            unfinishedTiles = unfinishedTiles.Where(x => !x.IsFullyRecoloured).ToList();
            RecolourBasedOnExistingTileColours(mostUsedGbColoursPerRealColourDictionary, unfinishedTiles);

            unfinishedTiles = unfinishedTiles.Where(x => !x.IsFullyRecoloured).ToList();

            var brightnessDictionary = mostUsedGbColoursPerRealColourDictionary.ToLookup(x => x.Key.GetPerceivedBrightness(), z => z);
            RecolourBasedOnNearestSimilarColours(unfinishedTiles);

            return _recolouredImage.Tiles;
        }

        private void RecolourBasedOnNearestSimilarColours(List<RecolouredTile> unfinishedTiles)
        {
            foreach (var unfinishedTile in unfinishedTiles)
            {
                if (_recolouredImage.TileDictionary.ContainsKey(unfinishedTile.OriginalTileHash))
                {
                    var colourDictionaryKey = _recolouredImage.TileDictionary[unfinishedTile.OriginalTileHash];
                    ProcessFromExistingTileDictionary(unfinishedTile, _recolouredImage.TileColourDictionary[colourDictionaryKey]);
                }
                else if (_recolouredImage.TileColourDictionary.ContainsKey(unfinishedTile.ColourKeyString))
                {
                    ProcessFromExistingTileDictionary(unfinishedTile, _recolouredImage.TileColourDictionary[unfinishedTile.ColourKeyString]);
                }
                else
                {
                    for (int i = 0; i < unfinishedTile.ColourMap.GetLength(0); i++)
                    {
                        for (int j = 0; j < unfinishedTile.ColourMap.GetLength(1); j++)
                        {
                            var currentColour = unfinishedTile[i, j];

                            if (currentColour.IsEmpty && unfinishedTile.IsFullyRecoloured)
                            {
                                // the colour has been found in a previous loop, and now its time to apply that colour to the remaining pixels
                                unfinishedTile[i, j] = unfinishedTile.ColourDictionary(unfinishedTile.OriginalTileColourMap[i, j]);
                            }
                            else if (currentColour.IsEmpty && !unfinishedTile.IsFullyRecoloured)
                            {
                                var remainingColourOptions = new List<Color> { GBWhite, GBLight, GBDark, GBBlack }.Except(unfinishedTile.Colours).ToDictionary(x => x.GetPerceivedBrightness(), z => z);
                                var currentOriginalColour = unfinishedTile.OriginalTileColourMap[i, j];
                                var currentOriginalColourBrightness = currentOriginalColour.GetPerceivedBrightness();

                                var closest = remainingColourOptions.OrderBy(x => Math.Abs(currentOriginalColourBrightness - x.Key)).First();

                                unfinishedTile[i, j] = closest.Value;
                                // still more colours to find
                            }
                            else
                            {
                                // pixel is good to go already
                                continue;
                            }
                        }
                    }
                    UpdateImageDictionaryCaches(_recolouredImage, unfinishedTile);
                }
            }
        }

        private static void RecolourBasedOnExistingTileColours(Dictionary<Color, Color> mostUsedGbColoursPerRealColourDictionary, List<RecolouredTile> unfinishedTiles)
        {
            foreach (var unfinishedTile in unfinishedTiles)
            {
                foreach (var ((i, j), colour) in unfinishedTile.ColourMap.ToIEnumerableWithCoords())
                {
                    var currentOriginalColour = unfinishedTile.OriginalTileColourMap[i, j];

                    if (mostUsedGbColoursPerRealColourDictionary.ContainsKey(currentOriginalColour))
                    {
                        unfinishedTile[i, j] = mostUsedGbColoursPerRealColourDictionary[currentOriginalColour];
                    }
                }
            }
        }

        private void RecolourBasedOnTransparentTiles(List<RecolouredTile> unfinishedTiles)
        {
            foreach (var unfinishedTile in unfinishedTiles)
            {
                if (unfinishedTile.OriginalColourCount == 1)
                {
                    var singleColour = unfinishedTile.OriginalColours.First();

                    if (singleColour.A == 0 && singleColour.R == 0 && singleColour.G == 0 && singleColour.B == 0)
                    {
                        foreach (var ((i, j), colour) in unfinishedTile.ColourMap.ToIEnumerableWithCoords())
                        {
                            unfinishedTile[i, j] = GBBlack;
                        }
                    }
                }
            }
        }

        private void RecolourBasedOnFourColourTiles(RecolouredImage recolouredImage)
        {
            var tiles = recolouredImage.Tiles.ToIEnumerable().OrderByDescending(x => x.OriginalColourCount).ToList();

            var tileGroups = tiles.GroupBy(x => x.OriginalColourCount).ToList();

            foreach (var tileGroup in tileGroups)
            {
                foreach (var tile in tileGroup)
                {
                    if (recolouredImage.TileDictionary.ContainsKey(tile.OriginalTileHash))
                    {
                        var colourDictionaryKey = recolouredImage.TileDictionary[tile.OriginalTileHash];
                        ProcessFromExistingTileDictionary(tile, recolouredImage.TileColourDictionary[colourDictionaryKey]);
                    }
                    else if (recolouredImage.TileColourDictionary.ContainsKey(tile.ColourKeyString))
                    {
                        ProcessFromExistingTileDictionary(tile, recolouredImage.TileColourDictionary[tile.ColourKeyString]);
                    }
                    else if (tile.OriginalColourCount == 4)
                    {
                        ProcessFourColours(tile);
                        UpdateImageDictionaryCaches(recolouredImage, tile);
                    }
                    else if (tile.OriginalColourCount == 1)
                    {

                    }
                    else
                    {
                        ProcessFromSimilarMoreColouredTiles(tile, tileGroups.Where(x => x.Key == tileGroup.Key + 1).First());

                        if (tile.Colours.Count == 0)
                        {
                            continue;
                        }

                        UpdateImageDictionaryCaches(recolouredImage, tile);
                    }
                }
            }
        }

        private static void UpdateImageDictionaryCaches(RecolouredImage recolouredImage, RecolouredTile tile)
        {
            var tileColourDictionaryKeys = tile.OriginalColours.OrderBy(x => x.GetPerceivedBrightness());
            var tileColourDictionaryValues = new List<Color>();

            foreach (var tileColour in tileColourDictionaryKeys)
            {
                tileColourDictionaryValues.Add(tile.ColourDictionary(tileColour));
            }

            recolouredImage.TileColourDictionary.TryAdd(tile.ColourKeyString, tile.ColourDictionaryCopy);

            recolouredImage.TileDictionary.TryAdd(tile.OriginalTileHash, tile.ColourKeyString);
        }

        private void ProcessFromExistingTileDictionary(RecolouredTile recolouredTile, Dictionary<Color, Color> dictionary)
        {
            for (int i = 0; i < recolouredTile.ColourMap.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTile.ColourMap.GetLength(1); j++)
                {
                    var originalColour = recolouredTile.OriginalTileColourMap[i, j];
                    recolouredTile[i, j] = dictionary[originalColour];
                }
            }
        }

        private void ProcessFromSimilarMoreColouredTiles(RecolouredTile recolouredTile, IEnumerable<RecolouredTile> tiles)
        {
            // go through the recolouredImage object to find something that has the same colours.      

            foreach (var tile in tiles)
            {
                if (tile.OriginalColourCount == tile.Colours.Count && tile.OriginalColours.ContainsAll(recolouredTile.OriginalColours))
                {
                    // found an n+1 colour tile that has all the n colours of this

                    for (int i = 0; i < recolouredTile.ColourMap.GetLength(0); i++)
                    {
                        for (int j = 0; j < recolouredTile.ColourMap.GetLength(1); j++)
                        {
                            var originalColour = recolouredTile.OriginalTileColourMap[i, j];
                            recolouredTile[i, j] = tile.ColourDictionary(originalColour);
                        }
                    }

                    return;

                }
            }
        }

        private void ProcessFourColours(RecolouredTile recolouredTile)
        {
            //var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var lightestToDarkestColours = recolouredTile.OriginalColours.OrderByDescending(x => x.GetPerceivedBrightness()).ToList();

            var localColourMap = lightestToDarkestColours.Zip(possibleGBColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            for (int i = 0; i < recolouredTile.ColourMap.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTile.ColourMap.GetLength(1); j++)
                {
                    recolouredTile[i, j] = localColourMap[recolouredTile.OriginalTileColourMap[i, j]];
                }
            }
        }
    }
}
