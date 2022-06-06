using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public static class Colouriser
    {
        // https://develop.gbstudio.dev/docs/sprites/
        // https://www.gbstudio.dev/docs/backgrounds/ 
        public static Color GBBlack => Color.FromArgb(7, 24, 33);
        public static Color GBDark => Color.FromArgb(48, 104, 80);
        public static Color GBLight => Color.FromArgb(134, 192, 108);
        public static Color GBWhite => Color.FromArgb(224, 248, 207);

        public static Bitmap ColouriseTile(Bitmap sourceImage)
        {
            if (sourceImage.Width > 8 || sourceImage.Height > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceImage));
            }

            var recolouredImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            var sourceColours = new HashSet<Color>();

            // find all colours in the original image
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    var color = sourceImage.GetPixel(i, j);

                    sourceColours.Add(color);

                    if (sourceColours.Count >= 4)
                    {
                        break;
                    }
                }

                if (sourceColours.Count >= 4)
                {
                    break;
                }
            }

            // sort colours from darkest to lightest



            // This map will need to work out if there is a "white" and a "black" and directly map the preset colours to those
            // this is useful because if a tile has 3 colours instead of 4, mapping will begin at the lightest to the darkest
            // meaning the lightest colour will be a "white" rather than the lightest version of that colour. 
            // Saying this because there seems to be a theme that GB colours can have which have a "white" and a "black" if 4
            // colours are being used. and if less colours are being used, then one of those presets are skipped
            var colourMapper = MapColours(sourceColours);



            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    var color = sourceImage.GetPixel(i, j);

                    var mappedColour = colourMapper[color];

                    recolouredImage.SetPixel(i, j, mappedColour);
                }
            }

            return recolouredImage;
        }

        public static Dictionary<Color, Color> MapColours(IEnumerable<Color> sourceColours)
        {

            var whites = GetWhites(sourceColours);
            var blacks = GetBlacks(sourceColours);

            var colourMapper = (whites.Count, blacks.Count, sourceColours.Count()) switch
            {
                //(_, _, 3) => ThreeColourMapper(sourceColours, whites, blacks),
                (_, _, _) => StandardMapper(sourceColours, whites, blacks)
            };

            return colourMapper;
        }

        public static Dictionary<Color, Color> StandardMapper(IEnumerable<Color> sourceColours, List<Color> whites, List<Color> blacks)
        {
            List<Color> orderedSourceColours = new List<Color>();
            List<Color> gbColours = new List<Color>();
            var colourMapper = new Dictionary<Color, Color>();

            if (whites.Count > 0 && blacks.Count == 0)
            {
                // at least one white

                // lightest to darkest
                orderedSourceColours = sourceColours.OrderByDescending(x => x.GetBrightness()).ToList();
                gbColours = new List<Color> { GBLight, GBDark, GBBlack };

                orderedSourceColours.Remove(whites[0]);

                colourMapper[whites[0]] = GBWhite;

            }
            else if (whites.Count == 0 && blacks.Count > 0)
            {
                // darkest to lightest
                orderedSourceColours = sourceColours.OrderBy(x => x.GetBrightness()).ToList();
                gbColours = new List<Color> { GBDark, GBLight, GBWhite };

                orderedSourceColours.Remove(blacks[0]);
                colourMapper[blacks[0]] = GBBlack;
            }
            else if (whites.Count > 0 && blacks.Count > 0)
            {
                // lightest to darkest
                orderedSourceColours = sourceColours.OrderByDescending(x => x.GetBrightness()).ToList();
                gbColours = new List<Color> { GBLight, GBDark };

                orderedSourceColours.Remove(whites[0]);
                orderedSourceColours.Remove(blacks[0]);

                colourMapper[whites[0]] = GBWhite;
                colourMapper[blacks[0]] = GBBlack;
            }
            else
            {
                // lightest to darkest
                orderedSourceColours = sourceColours.OrderByDescending(x => x.GetBrightness()).ToList();
                gbColours = new List<Color> { GBWhite, GBLight, GBDark, GBBlack };
            }

            var remainingColoursToMap = orderedSourceColours.Zip(gbColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            foreach (var (key, value) in remainingColoursToMap)
            {
                colourMapper.Add(key, value);
            }

            return colourMapper;
        }

        public static Dictionary<Color, Color> ThreeColourMapper(IEnumerable<Color> sourceColours, List<Color> whites, List<Color> blacks)
        {
            Color[] orderedSourceColours = Array.Empty<Color>();
            Color[] gbColours = Array.Empty<Color>();

            if (whites.Count > 0 && blacks.Count == 0)
            {
                // lightest to darkest
                orderedSourceColours = sourceColours.OrderByDescending(x => x.GetBrightness()).ToArray();
                gbColours = new[] { GBWhite, GBLight, GBDark, GBBlack };
            }
            else if (whites.Count == 0 && blacks.Count > 0)
            {
                // darkest to lightest
                orderedSourceColours = sourceColours.OrderBy(x => x.GetBrightness()).ToArray();
                gbColours = new[] { GBBlack, GBDark, GBLight, GBWhite };
            }
            else if (whites.Count > 0 && blacks.Count > 0)
            {

            }
            else
            {
                // lightest to darkest
                orderedSourceColours = sourceColours.OrderByDescending(x => x.GetBrightness()).ToArray();
                gbColours = new[] { GBWhite, GBLight, GBDark, GBBlack };
            }

            var colourMapper = orderedSourceColours.Zip(gbColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            //if (whites.Count > 0)
            //{
            //    colourMapper[whites[0]] = GBWhite;
            //}

            //if (blacks.Count > 0)
            //{
            //    colourMapper[blacks[0]] = GBBlack;
            //}

            return colourMapper;
        }

        public static Dictionary<Color, Color> CustomBrightnessMapper(IEnumerable<Color> sourceColours)
        {
            var orderedSourceColours = sourceColours.OrderBy(color => color.GetHue())
                .ThenBy(o => o.R * 3 + o.G * 2 + o.B * 1).ToArray().Reverse().ToArray();

            var gbColours = new[] { GBWhite, GBLight, GBDark, GBBlack };

            var colourMapper = orderedSourceColours.Zip(gbColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            return colourMapper;
        }

        public static List<Color> GetWhites(IEnumerable<Color> sourceColours)
        {
            var whiteList = new List<Color>();
            foreach (var item in sourceColours)
            {
                if (AreColoursClose(item, Color.White, 50))
                {
                    whiteList.Add(item);
                }
            }

            return whiteList;
        }

        public static List<Color> GetBlacks(IEnumerable<Color> sourceColours)
        {
            var blackList = new List<Color>();
            foreach (var item in sourceColours)
            {
                if (AreColoursClose(item, Color.Black, 100))
                {
                    blackList.Add(item);
                }
            }

            return blackList;
        }

        // https://stackoverflow.com/a/25168506
        public static bool AreColoursClose(Color a, Color z, int threshold = 50)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }
    }
}
