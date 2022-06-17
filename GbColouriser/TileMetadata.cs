using System;
using System.Collections;
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
        private Lazy<int> _hash;
    

        public TileMetadata()
        {
            _colourMap = new Color[8, 8];
            _colours = new HashSet<Color>();
            _hash = new Lazy<int>(() => GenerateHash()); // hm, this should be ensured to only be called after a load
        }

        public Color this[int x, int y]
        {
            get => _colourMap[x, y];
        }

        public int ColourHash => _hash.Value;

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

        private int GenerateHash()
        {
            // i couldnt work out how to make a hash that worked :/
            // couldnt get it working with adding in i and j values and bit shifting
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < _colourMap.GetLength(0); i++)
            {
                for (int j = 0; j < _colourMap.GetLength(1); j++)
                {
                    stringBuilder.Append(_colourMap[i, j]);
                }
            }

            return stringBuilder.ToString().GetHashCode();
        }
    }
}
