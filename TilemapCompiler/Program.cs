// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json;

var tilesDirectory = args[0];
var tilemapDetailsPath = args[1];
var outputPath = args[2];

var tilemapDetails = JsonSerializer.Deserialize<TilemapDetails>(File.ReadAllText(tilemapDetailsPath));
var tilemapDetailsRow = tilemapDetails.Tiles.Chunk(tilemapDetails.TilemapWidth);

var tilemapRow = new List<Bitmap>();


foreach (var rowTiles in tilemapDetailsRow)
{
    var bitmapRow = new Bitmap(tilemapDetails.TileWidth * tilemapDetails.TilemapWidth, tilemapDetails.TileHeight);

    foreach (var tile in rowTiles)
    {
        var tilePath = Path.Combine(tilesDirectory, tile.Filename);
        Bitmap tileImage;

        if (File.Exists(tilePath))
        {
            tileImage = new Bitmap(tilePath);            
        }
        else
        {
            tileImage = new Bitmap(tilemapDetails.TilemapWidth, tilemapDetails.TileHeight);

            using (Graphics gfx = Graphics.FromImage(tileImage))
            using (SolidBrush brush = new SolidBrush(Color.Fuchsia))
            {
                gfx.FillRectangle(brush, 0, 0, tilemapDetails.TilemapWidth, tilemapDetails.TileHeight);
            }
        }

        using (Graphics g = Graphics.FromImage(bitmapRow))
        {
            g.DrawImage(tileImage, Array.IndexOf(rowTiles, tile) * tilemapDetails.TileWidth, 0);
        }
    }

    tilemapRow.Add(bitmapRow);
}

var tilemapImage = new Bitmap(tilemapDetails.TileWidth * tilemapDetails.TilemapWidth, tilemapDetails.TileHeight * tilemapRow.Count);

for (int i = 0; i < tilemapRow.Count; i++)
{
    using (Graphics g = Graphics.FromImage(tilemapImage))
    {
        g.DrawImage(tilemapRow[i], 0, i * tilemapDetails.TileHeight);
    }
}

tilemapImage.Save(outputPath, ImageFormat.Png);


public class TilemapDetails
{
    public int TilemapWidth { get; set; }
    public int TileWidth { get; set; }
    public int TileHeight { get; set; }
    public Tile[] Tiles { get; set; }
}

public class Tile
{
    public string Name { get; set; }
    public string Filename { get; set; }
}
