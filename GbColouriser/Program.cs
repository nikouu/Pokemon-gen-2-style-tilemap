// See https://aka.ms/new-console-template for more information
using GbColouriser;
using System.Drawing;

Console.WriteLine("Hello, World!");

var threeColourTile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    @"GitHub\Pokemon-gen-2-style-tilemap/NewBuildingSample.png");

//threeColourTile = @"C:\Users\Niko Uusitalo\Documents\GitHub\Little-Mokki-In-The-Woods\LittleMokkiInTheWoods\assets\backgrounds\Mokki-area-export.png";
var image = new Bitmap(threeColourTile);

var colourisedImage = new Bitmap(image.Width, image.Height);

if (image.Width > 8 && image.Height > 8)
{
    for (int i = 0; i < image.Width; i += 8)
    {
        for (int j = 0; j < image.Height; j += 8)
        {
            var cloneRectangle = new Rectangle(i, j, 8, 8);

            // https://stackoverflow.com/a/59658657
            using var tile = image.Clone(cloneRectangle, image.PixelFormat);

            using var colouredTile = Colouriser.ColouriseTile(tile);

            using var g = Graphics.FromImage(colourisedImage);
            g.DrawImage(colouredTile, cloneRectangle);

        }
    }
}
else
{
    colourisedImage = Colouriser.ColouriseTile(image);
}


colourisedImage.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    @"GitHub\Pokemon-gen-2-style-tilemap/ayylmao2.png"));