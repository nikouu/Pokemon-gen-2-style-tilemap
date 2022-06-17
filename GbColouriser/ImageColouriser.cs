﻿using System;
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

        private Dictionary<List<Color>, List<Color>> _tileColourMap;

        private readonly int _width;
        private readonly int _height;
        private readonly Image _image;

        // probably need to work out then create a new colour information object that encompasses all those dictionaries

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
            _tileColourMap = new Dictionary<List<Color>, List<Color>>();
        }

        public Tile[,] Process()
        {
            var recolouredTiles = new Tile[_width / 8, _height / 8];

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
            if (_missingColours.Any())
            {
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
            }


            return recolouredTiles;
        }

        private void EstimateRemainingColours(Tile[,] recolouredTiles)
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
                            var missingColourBrightness = Brightness(missingColour);
                            var brightnessMap = tile.Colours.ToDictionary(x => x, y => Brightness(y));
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


                            if (missingColourBrightness > Brightness(closestColourByBrightness))
                            {
                                // put it at next brightest available space

                                for (int m = 0; m < gbColourMap.Count; m++)
                                {
                                    if (gbColourMap.ElementAt(m).Value == Color.Empty)
                                    {
                                        _missingColours.Remove(missingColour);
                                        _calculatedColourDictionary[missingColour] = gbColourMap.ElementAt(m).Key;
                                        break;
                                    }
                                }

                            }
                            else
                            {
                                // if missing colour is not brighter

                                for (int m = gbColourMap.Count - 1; m >= 0; m--)
                                {
                                    if (gbColourMap.ElementAt(m).Value == Color.Empty)
                                    {
                                        _missingColours.Remove(missingColour);
                                        _calculatedColourDictionary[missingColour] = gbColourMap.ElementAt(m).Key;
                                    }
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

        private void ProcessMissingColours(Tile[,] recolouredTiles)
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

        private void RecolourTiles(Tile[,] recolouredTiles)
        {
            var tileList = new List<Tile>();
            var tileCoords = new Dictionary<Tile, (int x, int y)>();

            for (int i = 0; i < _image.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _image.Tiles.GetLength(1); j++)
                {
                    var tile = _image.Tiles[i, j];

                    tileList.Add(tile);
                    tileCoords.Add(tile, (i, j));
                    //var colours = tile.Colours;

                    ////var recolouredTile = colours.Count switch
                    ////{
                    ////    1 => ProcessOneColour(tile),
                    ////    2 => ProcessTwoColours(tile),
                    ////    3 => ProcessThreeColours(tile),
                    ////    4 => ProcessFourColours(tile),
                    ////    _ => throw new Exception("Can't have more than four colours.")
                    ////};




                    //recolouredTiles[i, j] = recolouredTile;
                }
            }

            tileList = tileList.OrderByDescending(x => x.Colours.Count).ToList();

            foreach (var item in tileList)
            {
                var recolouredTile = item.Colours.Count switch
                {
                    4 => ProcessFourColours(item),
                    _ => ProcessFromSimilarMoreColouredTiles(item)
                };

                var (i, j) = tileCoords[item];
                recolouredTiles[i, j] = recolouredTile;

                // lol searching again
                //for (int i = 0; i < _image.Tiles.GetLength(0); i++)
                //{
                //    for (int j = 0; j < _image.Tiles.GetLength(1); j++)
                //    {
                //        var tile = _image.Tiles[i, j];

                //        if (tile.ColourHash == item.ColourHash)
                //        {
                //            recolouredTiles[i, j] = recolouredTile;
                //        }
                //    }
                //}
            }

        }

        private Tile ProcessFromSimilarMoreColouredTiles(Tile inputTile)
        {
            var recolouredTileColours = new Color[8, 8];

            // find a 4 colour that contains all the colours of this three colour
            var keyList = new HashSet<Color>();
            var valueList = new HashSet<Color>();

            foreach (var (key, value) in _tileColourMap.Where(x => x.Key.Count == inputTile.Colours.Count + 1))
            {                
                if (key.ContainsAll(inputTile.Colours))
                {
                    // found a 4 colour that has all the colours of this

                   

                    for (int i = 0; i < recolouredTileColours.GetLength(0); i++)
                    {
                        for (int j = 0; j < recolouredTileColours.GetLength(1); j++)
                        {
                            var inputColour = inputTile[i, j];

                            var indexOfProccessedTileColour = key.IndexOf(inputColour);

                            recolouredTileColours[i, j] = value[indexOfProccessedTileColour];

                            keyList.Add(inputColour);
                            valueList.Add(value[indexOfProccessedTileColour]);
                        }
                    }

                    break; // i think, if the colours are there we dont need to process anymore?
                }
            }

            _tileColourMap.Add(keyList.ToList(), valueList.ToList());

            var recolouredTile = new Tile();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private Tile ProcessOneColour(Tile inputTile)
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

            var recolouredTile = new Tile();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        // this can have 6 combinations
        private Tile ProcessTwoColours(Tile inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var localColourMap = new Dictionary<Color, Color>();
            var lightestToDarkestColours = inputTile.Colours.OrderByDescending(x => Brightness(x)).ToList();

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

            var recolouredTile = new Tile();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private Tile ProcessThreeColours(Tile inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var localColourMap = new Dictionary<Color, Color>();
            var colourGradient = new List<Color>();

            var whites = GetWhites(inputTile.Colours);
            var blacks = GetBlacks(inputTile.Colours);

            if (!whites.Any())
            {
                possibleGBColours.Remove(GBWhite);
            }
            else
            {
                localColourMap[whites[0]] = GBWhite;
            }

            if (!blacks.Any())
            {
                possibleGBColours.Remove(GBBlack);
            }
            else
            {
                localColourMap[blacks[0]] = GBBlack;
            }

            if (whites.Any() && !blacks.Any())
            {
                colourGradient = inputTile.Colours.OrderByDescending(x => Brightness(x)).ToList();
            }
            else if (!whites.Any() && blacks.Any())
            {
                colourGradient = inputTile.Colours.OrderBy(x => Brightness(x)).ToList();
                possibleGBColours.Reverse();
            }

            // we cant determine the final colour if it is a dark or light shade
            if (whites.Any() && blacks.Any())
            {
                // gotta come back to this one too

            }
            else
            {
                // a local colour map isnt created when there is an unknown colour

            }

            localColourMap = colourGradient.Zip(possibleGBColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);


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

            var recolouredTile = new Tile();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private Tile ProcessFourColours(Tile inputTile)
        {
            var recolouredTileColours = new Color[8, 8];
            var possibleGBColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            var lightestToDarkestColours = inputTile.Colours.OrderByDescending(x => Brightness(x)).ToList();

            var localColourMap = lightestToDarkestColours.Zip(possibleGBColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            _tileColourMap.TryAdd(localColourMap.Keys.ToList(), localColourMap.Values.ToList());

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

            var recolouredTile = new Tile();
            recolouredTile.LoadTile(recolouredTileColours);
            return recolouredTile;
        }

        private Tile ReprocessTile(Tile inputTile)
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

            var recolouredTile = new Tile();
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
