using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public class TileMetadata
    {
        private readonly Color[,] _colourMap;
        private readonly HashSet<Color> _colours;

        public TileMetadata()
        {
            _colourMap = new Color[8, 8];
            _colours = new HashSet<Color>();
        }

        public Color this[int x, int y]
        {
            get => _colourMap[x, y];
        }

        public HashSet<Color> Colours => _colours;

        public void LoadTile(Bitmap tile)
        {
            if (tile.Width > 8 || tile.Height > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(tile));
            }

            for (int i = 0; i < tile.Width; i++)
            {
                for (int j = 0; j < tile.Height; j++)
                {
                    var colour = tile.GetPixel(i, j);

                    _colourMap[i, j] = colour;
                    _colours.Add(colour);
                }
            }
        }

        public void LoadTile(Color[,] rawColours)
        {
            for (int i = 0; i < rawColours.GetLength(0); i++)
            {
                for (int j = 0; j < rawColours.GetLength(1); j++)
                {
                    _colourMap[i, j] = rawColours[i, j];
                    _colours.Add(rawColours[i, j]);
                }
            }
        }
    }
}
