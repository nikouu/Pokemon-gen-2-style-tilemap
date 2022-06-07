// See https://aka.ms/new-console-template for more information
using GbColouriser;
using System.Drawing;

Console.WriteLine("Hello, World!");

var threeColourTile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    @"GitHub\Pokemon-gen-2-style-tilemap/Custom/Building-roof-flat-04.png");

threeColourTile = @"C:\Users\Niko Uusitalo\Documents\GitHub\Little-Mokki-In-The-Woods\LittleMokkiInTheWoods\assets\backgrounds\Mokki-area-export.png";
var image = new Bitmap(threeColourTile);


var imageData = new GbColouriser.Image(image.Width, image.Height);

imageData.LoadImage(image);

var recolouredImage = imageData.Recolour();

recolouredImage.Save(@"C:\Users\Niko Uusitalo\Documents\GitHub\Pokemon-gen-2-style-tilemap\ayylmao2.png");

