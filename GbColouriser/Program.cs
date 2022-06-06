// See https://aka.ms/new-console-template for more information
using GbColouriser;
using System.Drawing;

Console.WriteLine("Hello, World!");

var threeColourTile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    @"GitHub\Pokemon-gen-2-style-tilemap/Original/Building-window.png");

var image = new Bitmap(threeColourTile);

var colourisedImage = new Bitmap(image.Width, image.Height);

if (image.Width > 8 && image.Height > 8)
{
    for (int i = 0; i < image.Width; i = i + 8)
    {
        for (int j = 0; j < image.Height; j = j + 8 )
        {
            var cloneRectangle = new Rectangle(i, j, 8, 8);
            var tile = image.Clone(cloneRectangle, image.PixelFormat);

            var colouredTile = Colouriser.ColouriseTile(tile);

            using (Graphics g = Graphics.FromImage(colourisedImage))
            {
                g.DrawImage(colouredTile, cloneRectangle);
            }
        }
    }
}
else
{
    colourisedImage = Colouriser.ColouriseTile(image);
}


colourisedImage.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    @"GitHub\Pokemon-gen-2-style-tilemap/ayylmao.png"));