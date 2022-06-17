using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public class RecolouredImage
    {
        private readonly Image _originalImage;
        
        private readonly RecolouredTile[,] _recolouredTiles;

        // Keys being the colours in the tile, ordered by brightness, and values being the gb colours, in the same order
        public Dictionary<string, Dictionary<Color, Color>> TileColourDictionary;

        // Keys being the "hash" of the tile. Allows quick lookup for Colour dictionary for previously seen identical tiles
        public Dictionary<int, string> TileDictionary;


        public RecolouredImage(Image originalImage)
        {
            _originalImage = originalImage;
            _recolouredTiles = new RecolouredTile[_originalImage.Width / 8, _originalImage.Height / 8];
            TileColourDictionary = new Dictionary<string, Dictionary<Color, Color>>();
            TileDictionary = new Dictionary<int, string>();

            SetupTiles();
        }

        public RecolouredTile[,] Tiles => _recolouredTiles;

        public ITile[,] OriginalTiles => _originalImage.Tiles;

        private void SetupTiles()
        {
            var originalTileIterator = _originalImage.Tiles.ToIEnumerable();
            foreach (var originalTile in originalTileIterator)
            {
                _recolouredTiles[originalTile.Coordinate.X, originalTile.Coordinate.Y] = new RecolouredTile(originalTile);
            }
        }
    }
}
