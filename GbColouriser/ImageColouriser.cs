using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public class ImageColouriser
    {
        private readonly Image _image;
        private readonly RecolouredImage _recolouredImage;

        // probably need to work out then create a new colour information object that encompasses all those dictionaries

        private Color GBWhite => Color.FromArgb(224, 248, 207);
        private Color GBLight => Color.FromArgb(134, 192, 108);
        private Color GBDark => Color.FromArgb(48, 104, 80);
        private Color GBBlack => Color.FromArgb(7, 24, 33);
        private Color GBMissing => Color.Empty; // special missing colour 


        public ImageColouriser(Image image)
        {
            _image = image;

            _recolouredImage = new RecolouredImage(image);
        }

        public ITile[,] Process()
        {
            //var recolouredTiles = new Tile[_width / 8, _height / 8];

            //// 1. Get all the colours into the dictionary
            //for (int i = 0; i < _width; i++)
            //{
            //    for (int j = 0; j < _height; j++)
            //    {
            //        var colour = _image.GetPixel(i, j);
            //        if (!_collectedColoursDictionary.ContainsKey(colour))
            //        {
            //            _collectedColoursDictionary[colour] = new List<Color>();
            //        }
            //    }
            //}

            // 2. Recolour the tiles
            RecolourTiles(_recolouredImage);

            // 3. Calculate the colour dictionary
            //CalculateColourDictionary();


            //// if any of the values have zero as a value
            //if (_collectedColoursDictionary.Select(x => x.Value.Count()).Where(z => z == 0).Any())
            //{
            //    // map up missing colours to the colour dictionary before reprocessing

            //    // 3. Work out missing tile colour values
            //    Dictionary<Color, Color> adjustedColourDictionary = FindMissingColours();
            //}           

            // 4. Reprocess tiles with worked out colour values
            //ProcessMissingColours(recolouredTiles);

            // i need a weighted reproccessing step, that goes "for each true colour, what has the biggest weight to it
            // or if there are other tiles that use the same true colours, look to them and take a weighted guess

            // if there are any coloursl left over, we have to make a decision on what colour they are. 

            //EstimateRemainingColours(recolouredTiles);

            //ProcessMissingColours(recolouredTiles);

            // back to the estimation work. dont have to estimate 4 colours, just 3, 2, and 1. 

            // the lighest colour in the whole set and the darkest are easy to assign colours to, just in case they already werent assigned?

            // can prob start grouping tiles by their colours. because each tile that contains the same x colours will have teh same shading
            // so working one out will work all the others out that have the same

            // perhaps group all the true colours in order. so all the "whites", "lights" etc so there is one continunous list colours
            // ordered by their colour and as such maybe ordered by their gb colour groups. could maybe use that to help determine 
            // a single missing colour or something - just where that missing colour fits in the brightness spectrum

            // work on tiles with fewest missing colours, or greatest first? maybe greatest since we can have the most comparisons between
            // colours and thus eliminating guesswork for which: "lighter" or "darker" to apply to that tile

            // mayube have a RecolouredTile object which has reference to the original tile, but all the colouring metadata like the
            // dictionaries above and can reason about the current state of the tiles recolouring. maybe this object could inherit 
            // from tilemetadata then can take in a tile as an input parameter for the constructor

            // maybe another obejct that is the recoloured image. which is full of recolouredTiles. allows us to query against all
            // the recoloured tiles, like looking at all thecolours in the whole image

            // so new control flow could be
            // 1. get all the 4 colour tiles done
            // 2. propagate down those 4 colours
            // 3. pick out darkest and lightest tiles and assign values
            // 4. do a pass with the lightest and darkest tiles, that might change some 3 missing colours to a 2 or something
            // 5. work through 3 missing colour tiles
            // 6. propogate those down too
            // 7. repeat with two colour tiles
            // 8. propgate down
            // 9. make an educated guess with any single colour tiles based on the brightness scale


            return _recolouredImage.Tiles;
        }

        private void RecolourTiles(RecolouredImage recolouredImage)
        {
            var tiles = recolouredImage.Tiles.TileIterator().OrderByDescending(x => x.OriginalColourCount).ToList();

            var tileGroups = tiles.GroupBy(x => x.OriginalColourCount).ToList();

            foreach (var tileGroup in tileGroups)
            {
                foreach (var tile in tileGroup)
                {
                    if (recolouredImage.TileDictionary.ContainsKey(tile.OriginalTileHash))
                    {
                        var colourDictionaryKey = recolouredImage.TileDictionary[tile.OriginalTileHash];
                        //Console.WriteLine("cache hit");
                        ProcessFromExistingTileDictionary(tile, recolouredImage.TileColourDictionary[colourDictionaryKey]);
                    }
                    else if (recolouredImage.TileColourDictionary.ContainsKey(tile.ColourKeyString))
                    {
                        //Console.WriteLine("cache hit2");
                        ProcessFromExistingTileDictionary(tile, recolouredImage.TileColourDictionary[tile.ColourKeyString]);
                    }
                    else if (tile.OriginalColourCount == 4)
                    {
                        ProcessFourColours(tile);
                        var tileColourDictionaryKeys = tile.OriginalColours.OrderBy(x => x.GetPerceivedBrightness());
                        var tileColourDictionaryValues = new List<Color>();

                        foreach (var tileColour in tileColourDictionaryKeys)
                        {
                            tileColourDictionaryValues.Add(tile.ColourDictionary(tileColour));
                        }

                        recolouredImage.TileColourDictionary.TryAdd(tile.ColourKeyString, tile.ColourDictionaryCopy);

                        recolouredImage.TileDictionary.TryAdd(tile.OriginalTileHash, tile.ColourKeyString);

                    }
                    else
                    {
                        ProcessFromSimilarMoreColouredTiles(tile, tileGroups.Where(x => x.Key == tileGroup.Key + 1).First());

                        if (tile.Colours.Count == 0)
                        {
                            continue;
                        }

                        var tileColourDictionaryKeys = tile.OriginalColours.OrderBy(x => x.GetPerceivedBrightness());
                        var tileColourDictionaryValues = new List<Color>();

                        foreach (var tileColour in tileColourDictionaryKeys)
                        {
                            tileColourDictionaryValues.Add(tile.ColourDictionary(tileColour));
                        }

                        recolouredImage.TileColourDictionary.TryAdd(tile.ColourKeyString, tile.ColourDictionaryCopy);

                        recolouredImage.TileDictionary.TryAdd(tile.OriginalTileHash, tile.ColourKeyString);
                    }
                }
            }

            //foreach (var tile in tiles)
            //{
            //    switch (tile.OriginalColours.Count)
            //    {
            //        case 4:
            //            ProcessFourColours(tile);
            //            break;
            //        default:
            //            var tileSubset = groupedTiles.;
            //            ProcessFromSimilarMoreColouredTiles(tile, tileSubset);
            //            break;
            //    }
            //}
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

        private List<Color> GetWhites(IEnumerable<Color> sourceColours)
        {
            var whiteList = new List<Color>();
            foreach (var item in sourceColours)
            {
                if (IsWhite(item))
                {
                    whiteList.Add(item);
                }
            }

            return whiteList;
        }

        private List<Color> GetBlacks(IEnumerable<Color> sourceColours)
        {
            var blackList = new List<Color>();
            foreach (var item in sourceColours)
            {
                if (IsBlack(item))
                {
                    blackList.Add(item);
                }
            }

            return blackList;
        }

        private bool IsWhite(Color colour) => AreColoursClose(colour, Color.White, 50);
        private bool IsBlack(Color colour) => AreColoursClose(colour, Color.Black, 100);

        // https://stackoverflow.com/a/25168506
        private bool AreColoursClose(Color a, Color z, int threshold = 50)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }
    }
}
