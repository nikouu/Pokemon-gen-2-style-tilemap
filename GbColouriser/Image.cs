using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public class Image
    {
        private readonly int _width;
        private readonly int _height;

        private readonly Tile[,] _tiles;

        public Image(int width, int height)
        {
            _width = width;
            _height = height;
            _tiles = new Tile[width / 8, height / 8];
        }

        public Tile[,] Tiles => _tiles;
        public int Width => _width;
        public int Height => _height;

        public void LoadImage(Bitmap image)
        {
            // https://stackoverflow.com/a/9691388
            var rawImage = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            var imageByteCount = rawImage.Stride * rawImage.Height;
            var imageBytes = new byte[imageByteCount];

            var croppedBitmap = new Bitmap(8, 8); // maybe this gets properly reused between runs?


            Marshal.Copy(rawImage.Scan0, imageBytes, 0, imageByteCount);

            for (int i = 0; i < image.Width; i += 8)
            {
                for (int j = 0; j < image.Height; j += 8)
                {
                    var croppedBytes = GetCroppedImage(imageBytes, rawImage.Stride, i, j, 8, 8);
                    var croppedData = croppedBitmap.LockBits(new Rectangle(0, 0, 8, 8), ImageLockMode.WriteOnly, image.PixelFormat);

                    Marshal.Copy(croppedBytes, 0, croppedData.Scan0, croppedBytes.Length);

                    croppedBitmap.UnlockBits(croppedData);

                    _tiles[i / 8, j / 8] = new Tile();
                    _tiles[i / 8, j / 8].LoadTile(croppedBitmap, i / 8, j / 8);
                }
            }

            image.UnlockBits(rawImage);
        }

        public Bitmap Recolour()
        {
            var imageProcessor = new ImageColouriser(this);
            var tiles = imageProcessor.Process();

            var recolouredImage = new Bitmap(_width, _height);

            for (int i = 0; i < _width; i ++)
            {
                for (int j = 0; j < _height; j ++)
                {
                    var tileArrayX = i / 8;
                    var tileArrayY = j / 8;

                    var tileX = i % 8;
                    var tileY = j % 8;

                    var tile = tiles[tileArrayX, tileArrayY];

                    var colour = tile[tileX, tileY];

                    
                    recolouredImage.SetPixel(i, j, colour);
                }
            }

            return recolouredImage;
        }

        public Color GetPixel(int x, int y)
        {
            var tileArrayX = x / 8;
            var tileArrayY = y / 8;

            var tileX = x % 8;
            var tileY = y % 8;

            var tile = _tiles[tileArrayX, tileArrayY];

            var colour = tile[tileX, tileY];

            return colour;
        }

        private byte[] GetCroppedImage(byte[] imageBytes, int stride, int x, int y, int width, int height)
        {
            var bpp = 4;
            byte[] croppedBytes = new byte[width * height * bpp];


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width * bpp; j += bpp)
                {
                    int origIndex = (y * stride) + (i * stride) + (x * bpp) + (j);
                    int croppedIndex = (i * width * bpp) + (j);

                    //copy data: once for each channel
                    for (int k = 0; k < bpp; k++)
                    {
                        croppedBytes[croppedIndex + k] = imageBytes[origIndex + k];
                    }
                }
            }

            return croppedBytes;
        }
    }
}
