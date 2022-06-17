using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public class RecolouredTile : ITile
    {
        private readonly Tile _originalTile;

        private readonly Color[,] _gbColourMap;

        private readonly HashSet<Color> _gbColours;

        private int _hash;

        public RecolouredTile(Tile originalTile)
        {
            _originalTile = originalTile;
            _gbColours = new HashSet<Color>();
            _gbColourMap = new Color[8, 8];
        }

        public Color this[int x, int y]
        {
            get => _gbColourMap[x, y];
        }

        public int ColourHash => _hash;

        public HashSet<Color> Colours => _gbColours;

        // can be made lazy/cached
        public HashSet<Color> OriginalColours => _originalTile.Colours;

        public Point Coordinate => _originalTile.Coordinate;
    }
}
