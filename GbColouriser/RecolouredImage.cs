using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public class RecolouredImage
    {
        private readonly Image _originalImage;
        
        private readonly RecolouredTile[,] _recolouredTiles;

        public RecolouredImage(Image originalImage)
        {
            _originalImage = originalImage;
            _recolouredTiles = new RecolouredTile[_originalImage.Width / 8, _originalImage.Height / 8];
            SetupTiles();
        }

        private void SetupTiles()
        {
            var originalTileIterator = _originalImage.Tiles.TileIterator();
            foreach (var originalTile in originalTileIterator)
            {
                _recolouredTiles[originalTile.Coordinate.X, originalTile.Coordinate.Y] = new RecolouredTile(originalTile);
            }
        }
    }
}
