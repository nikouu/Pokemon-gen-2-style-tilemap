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
        public static Color GBColour00 => Color.FromArgb(7, 24, 33);
        public static Color GBColour01 => Color.FromArgb(48, 104, 80);
        public static Color GBColour02 => Color.FromArgb(134, 192, 108);
        public static Color GBColour03 => Color.FromArgb(224, 248, 207);

        // Supreme stuffed crust 
        public static Color[] GBColours = new[] { GBColour03, GBColour02, GBColour01, GBColour00 };

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
            var orderedSourceColours = sourceColours.OrderByDescending(x => x.GetBrightness()).ToArray();

            var colourMapper = orderedSourceColours.Zip(GBColours, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

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
    }
}
