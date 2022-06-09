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
        private Dictionary<Color, List<Color>> _collectedColoursDictionary;
        private HashSet<Color> _missingColours;
        private Dictionary<Color, Color> _calculatedColourDictionary;

        private readonly int _width;
        private readonly int _height;
        private readonly Image _image;

        private Color GBWhite => Color.FromArgb(224, 248, 207);
        private Color GBLight => Color.FromArgb(134, 192, 108);
        private Color GBDark => Color.FromArgb(48, 104, 80);
        private Color GBBlack => Color.FromArgb(7, 24, 33);
        private Color GBMissing => Color.Empty; // special missing colour 


        public ImageColouriser(int width, int height, Image image)
        {
            _width = width;
            _height = height;
            _image = image;
            _collectedColoursDictionary = new Dictionary<Color, List<Color>>();
            _missingColours = new HashSet<Color>();
            _calculatedColourDictionary = new Dictionary<Color, Color>();
        }

        public TileMetadata[,] Process()
        {
            var recolouredTiles = new TileMetadata[_width / 8, _height / 8];

            // 1. Get all the colours into the dictionary
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    var colour = _image.GetPixel(i, j);
                    if (!_collectedColoursDictionary.ContainsKey(colour))
                    {
                        _collectedColoursDictionary[colour] = new List<Color>();
                    }
                }
            }

            // 2. Recolour the tiles
            RecolourTiles(recolouredTiles);

            // 3. Calculate the colour dictionary
            CalculateColourDictionary();


            //// if any of the values have zero as a value
            //if (_collectedColoursDictionary.Select(x => x.Value.Count()).Where(z => z == 0).Any())
            //{
            //    // map up missing colours to the colour dictionary before reprocessing

            //    // 3. Work out missing tile colour values
            //    Dictionary<Color, Color> adjustedColourDictionary = FindMissingColours();
            //}           

            // 4. Reprocess tiles with worked out colour values
            ProcessMissingColours(recolouredTiles);

            // if there are any coloursl left over, we have to make a decision on what colour they are. 
            if (_missingColours.Any())
            {
                EstimateRemainingColours(recolouredTiles);

                ProcessMissingColours(recolouredTiles);
            }


            return recolouredTiles;
        }

        private void EstimateRemainingColours(TileMetadata[,] recolouredTiles)
        {
            for (int i = 0; i < _image.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _image.Tiles.GetLength(1); j++)
                {
                    var tile = recolouredTiles[i, j];
                    var missingColours = tile.Colours.Intersect(_missingColours);

                    if (missingColours.Any())
                    {
                        var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
                        var existingGBColourMap = _calculatedColourDictionary.Where(x => tile.Colours.Contains(x.Value)).ToDictionary(x => x.Key, x => x.Value);

                        var gbColourMap = new Dictionary<Color, Color>(); // key is the original colour

                        foreach (var item in possibleGBColours)
                        {
                            if (existingGBColourMap.ContainsValue(item))
                            {
                                gbColourMap[item] = existingGBColourMap.First(x => x.Value == item).Key;
                            }
                            else
                            {
                                gbColourMap[item] = Color.Empty;
                            }
                        }

                        if (missingColours.Count() == 1)
                        {
                            var missingColour = missingColours.First();
                            var missingColourBrightness = missingColour.GetBrightness();
                            var brightnessMap = tile.Colours.ToDictionary(x => x, y => y.GetBrightness());
                            brightnessMap.Remove(missingColour); // so it doesnt find itself                      

                            // a single colour tile on its own that could not be determined
                            if (brightnessMap.Count == 0)
                            {
                                _missingColours.Remove(missingColour);
                                _calculatedColourDictionary[missingColour] = GBBlack;
                                continue;
                            }


                            var closestColourByBrightness = brightnessMap.OrderBy(x => Math.Abs(x.Value - missingColourBrightness)).First().Key;

                            var indexOfBrightestColour = 0;

                            foreach (var (key, value) in gbColourMap)
                            {
                                if (key == closestColourByBrightness)
                                {
                                    break;
                                }
                                indexOfBrightestColour++;
                            }


                            if (missingColourBrightness > closestColourByBrightness.GetBrightness())
                            {
                                // if missing colour is brighter
                            }
                            else
                            {
                                // if missing colour is not brighter
                                if (gbColourMap.ElementAt(indexOfBrightestColour + 1).Value == Color.Empty)
                                {
                                    _missingColours.Remove(missingColour);
                                    _calculatedColourDictionary[missingColour] = gbColourMap.ElementAt(indexOfBrightestColour + 1).Key;
                                }
                                else
                                {
                                    // uh oh

                                }


                            }


                        }
                        else if (missingColours.Count() == 2)
                        {

                        }
                        else if (missingColours.Count() == 3)
                        {

                        }
                        else
                        {
                            throw new Exception("How did we get here?");
                        }
                                               

                        // missing colour(s) found.
                    }
                }
            }
        }

        private void ProcessMissingColours(TileMetadata[,] recolouredTiles)
        {
            for (int i = 0; i < _image.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _image.Tiles.GetLength(1); j++)
                {
                    var tile = recolouredTiles[i, j];

                    var recolouredTile = ReprocessTile(tile);

                    recolouredTiles[i, j] = recolouredTile;
                }
            }
        }

        private void CalculateColourDictionary()
        {
            foreach (var (key, value) in _collectedColoursDictionary)
            {
                if (value.Count == 0)
                {
                    // put it in the new dictionary? prob not actually?
                }
                else
                {
                    var mostPickedColour = value.GroupBy(x => x).OrderByDescending(g => g.Count()).First().First(); // lol
                    _calculatedColourDictionary[key] = mostPickedColour;
                    _missingColours.Remove(key);
                }
            }


            //var multipleColoursMappedToColourDictionary = _collectedColoursDictionary.Where(x => x.Value.Distinct().Count() > 1);

            //var fixDictionary = new Dictionary<Color, List<Tuple<int, Color>>>();

            //foreach (var (key, value) in multipleColoursMappedToColourDictionary)
            //{
            //    var distinctColours = value.Distinct();
            //    var tupleList = new List<Tuple<int, Color>>();

            //    foreach (var distinctColour in distinctColours)
            //    {
            //        var colourCount = value.Where(x => x == distinctColour).Count();
            //        tupleList.Add(new Tuple<int, Color>(colourCount, distinctColour));
            //    }
            //    fixDictionary[key] = tupleList;
            //}

            //var adjustedColourDictionary = new Dictionary<Color, Color>();

            //var problemColours = fixDictionary.Where(x => x.Value.Any(z => z.Item2 == GBMissing));

            //foreach (var (key, value) in problemColours)
            //{
            //    var colourToMapTo = value.Where(x => x.Item2 != GBMissing).OrderByDescending(z => z.Item1).First().Item2;
            //    adjustedColourDictionary[key] = colourToMapTo;
            //}

            //return adjustedColourDictionary;
        }

        private void RecolourTiles(TileMetadata[,] recolouredTiles)
        {
            for (int i = 0; i < _image.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _image.Tiles.GetLength(1); j++)
                {
                    var tile = _image.Tiles[i, j];
                    var colours = tile.Colours;

                    var recolouredTile = colours.Count switch
                    {
                        1 => ProcessOneColour(tile),
                        2 => ProcessTwoColours(tile),
                        3 => ProcessThreeColours(tile),
                        4 => ProcessFourColours(tile),
                        _ => throw new Exception("Can't have more than four colours.")
                    };

                    recolouredTiles[i, j] = recolouredTile;
                }
            }
        }

        private TileMetadata ProcessOneColour(TileMetadata inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var whites = GetWhites(inputTile.Colours);
            var blacks = GetBlacks(inputTile.Colours);

            for (int i = 0; i < recolouredTileColours.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTileColours.GetLength(1); j++)
                {
                    var inputColour = inputTile[i, j];
                    var calculatedColour = (whites.Count, blacks.Count) switch
                    {
                        (0, 0) => inputColour, // come back to this later to see if it can be worked out after other tiles have been processed
                        (0, 1) => GBBlack,
                        (1, 0) => GBWhite,
                        (_, _) => throw new Exception("How did we get here?")
                    };

                    if (inputColour == calculatedColour)
                    {
                        _missingColours.Add(calculatedColour);
                    }
                    else
                    {
                        _collectedColoursDictionary[inputColour].Add(calculatedColour);
                    }

                    recolouredTileColours[i, j] = calculatedColour;
                }
            }

            var recolouredTile = new TileMetadata();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        // this can have 6 combinations
        private TileMetadata ProcessTwoColours(TileMetadata inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var localColourMap = new Dictionary<Color, Color>();
            var lightestToDarkestColours = inputTile.Colours.OrderByDescending(x => x.GetBrightness()).ToList();

            var whites = GetWhites(inputTile.Colours);
            var blacks = GetBlacks(inputTile.Colours);

            // this doesnt account for multiple black or whites
            if (!whites.Any())
            {
                possibleGBColours.Remove(GBWhite);
            }
            else if (whites.Count() == 1)
            {
                localColourMap[whites[0]] = GBWhite;
            }
            else
            {
                // issue if there are multiple white candidates 
            }

            if (!blacks.Any())
            {
                possibleGBColours.Remove(GBBlack);
            }
            else if (blacks.Count() == 1)
            {
                localColourMap[blacks[0]] = GBBlack;
            }
            else
            {
                // issue if there are multiple white candidates 
            }

            // no white or black, meaning only light and dark
            if (possibleGBColours.Count == 2)
            {
                localColourMap[lightestToDarkestColours[0]] = GBLight;
                localColourMap[lightestToDarkestColours[1]] = GBDark;
            }
            else
            {
                // need to work out at a later stage how to map these colours
                // because if a black and a dark come in, we remove the white, but since it's two colours
                // we dont know if the non black colour is a light or a dark with this knowledge
                // will need to return when we know more about that colour
            }


            for (int i = 0; i < recolouredTileColours.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTileColours.GetLength(1); j++)
                {
                    var inputColour = inputTile[i, j];

                    var calculatedColour = localColourMap.ContainsKey(inputColour) switch
                    {
                        true => localColourMap[inputColour],
                        false => inputColour
                    };

                    if (inputColour == calculatedColour)
                    {
                        _missingColours.Add(calculatedColour);
                    }
                    else
                    {
                        _collectedColoursDictionary[inputColour].Add(calculatedColour);
                    }

                    recolouredTileColours[i, j] = calculatedColour;
                }
            }

            var recolouredTile = new TileMetadata();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private TileMetadata ProcessThreeColours(TileMetadata inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var localColourMap = new Dictionary<Color, Color>();
            var lightestToDarkestColours = inputTile.Colours.OrderByDescending(x => x.GetBrightness()).ToList();

            var whites = GetWhites(inputTile.Colours);
            var blacks = GetBlacks(inputTile.Colours);

            //if (!whites.Any())
            //{
            //    possibleGBColours.Remove(GBWhite);
            //}
            //else
            //{
            //    localColourMap[whites[0]] = GBWhite;
            //}

            //if (!blacks.Any())
            //{
            //    possibleGBColours.Remove(GBBlack);
            //}
            //else
            //{
            //    localColourMap[blacks[0]] = GBBlack;
            //}

            // we cant determine the final colour if it is a dark or light shade
            if (whites.Any() && blacks.Any())
            {
                // gotta come back to this one too

            }
            else
            {
                // a local colour map isnt created when there is an unknown colour
                localColourMap = lightestToDarkestColours.Zip(possibleGBColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            }

            for (int i = 0; i < recolouredTileColours.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTileColours.GetLength(1); j++)
                {
                    var inputColour = inputTile[i, j];

                    var calculatedColour = localColourMap.ContainsKey(inputColour) switch
                    {
                        true => localColourMap[inputColour],
                        false => inputColour
                    };

                    if (inputColour.R == 255 && inputColour.G == 255)
                    {

                    }
                    else
                    {

                    }

                    if (inputColour == calculatedColour)
                    {
                        _missingColours.Add(calculatedColour);
                    }
                    else
                    {
                        _collectedColoursDictionary[inputColour].Add(calculatedColour);
                    }

                    recolouredTileColours[i, j] = calculatedColour;
                }
            }

            var recolouredTile = new TileMetadata();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private TileMetadata ProcessFourColours(TileMetadata inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var lightestToDarkestColours = inputTile.Colours.OrderByDescending(x => x.GetBrightness()).ToList();

            var localColourMap = lightestToDarkestColours.Zip(possibleGBColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            for (int i = 0; i < recolouredTileColours.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTileColours.GetLength(1); j++)
                {
                    var inputColour = inputTile[i, j];

                    var calculatedColour = localColourMap[inputColour];

                    _collectedColoursDictionary[inputColour].Add(calculatedColour);

                    recolouredTileColours[i, j] = calculatedColour;
                }
            }

            var recolouredTile = new TileMetadata();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private TileMetadata ReprocessTile(TileMetadata inputTile)
        {
            var recolouredTileColours = new Color[8, 8];

            for (int i = 0; i < recolouredTileColours.GetLength(0); i++)
            {
                for (int j = 0; j < recolouredTileColours.GetLength(1); j++)
                {
                    var inputColour = inputTile[i, j];

                    if (inputColour.R == 255 && inputColour.G == 255)
                    {

                    }
                    else
                    {

                    }

                    var colour = _calculatedColourDictionary.ContainsKey(inputColour) switch
                    {
                        true => _calculatedColourDictionary[inputColour],
                        false => inputColour
                    };


                    recolouredTileColours[i, j] = colour;
                }
            }

            var recolouredTile = new TileMetadata();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
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

        // https://www.nbdtech.com/Blog/archive/2008/04/27/calculating-the-perceived-brightness-of-a-color.aspx
        private static int Brightness(Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }
    }
}
