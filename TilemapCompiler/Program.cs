// See https://aka.ms/new-console-template for more information
using Markdig;
using Markdig.Extensions.Tables;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json;

var tilesDirectory = args[0];
var tilemapDetailsPath = args[1];
var outputPath = args[2];
var readmePath = args[3];

var pipline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
var readmeMarkdown = Markdown.Parse(File.ReadAllText(readmePath), pipline);

var tileListFromMarkdown = new List<Tile>();

foreach (var table in readmeMarkdown.Descendants<Table>())
{
    var firstColumnHeader = table?.Descendants<TableRow>()?.ElementAt(0)
                                 ?.Descendants<TableCell>()?.ElementAt(0)
                                 ?.Descendants<LiteralInline>().ElementAt(0)
                                 ?.ToString();

    var secondColumnHeader = table?.Descendants<TableRow>()?.ElementAt(0)
                                 ?.Descendants<TableCell>()?.ElementAt(1)
                                 ?.Descendants<LiteralInline>().ElementAt(0)
                                 ?.ToString();

    var thirdColumnHeader = table?.Descendants<TableRow>()?.ElementAt(0)
                                 ?.Descendants<TableCell>()?.ElementAt(2)
                                 ?.Descendants<LiteralInline>().ElementAt(0)
                                 ?.ToString();

    bool isCorrectTable = (firstColumnHeader, secondColumnHeader, thirdColumnHeader) switch
    {
        ("Tile", "Original", "Custom") => true,
        _ => false
    };

    if (!isCorrectTable)
    {
        continue;
    }

    var rows = table.Descendants<TableRow>().Skip(1).Select(row => new Tile
    {
        Name = row.Descendants<TableCell>().ElementAt(0).Descendants<LiteralInline>().FirstOrDefault().ToString(),
        Filename = Path.GetFileName(row.Descendants<TableCell>().ElementAt(1).Descendants<LinkInline>().ElementAt(0).Url).Replace("_large", "")

    });

    tileListFromMarkdown.AddRange(rows);
}

var tilemapDetails = JsonSerializer.Deserialize<TilemapDetails>(File.ReadAllText(tilemapDetailsPath));
//var tilemapDetailsRow = tilemapDetails.Tiles.Chunk(tilemapDetails.TilemapWidth);

var tilemapDetailsRow = tileListFromMarkdown.Chunk(tilemapDetails.TilemapWidth);


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

tilemapDetails.Tiles = tileListFromMarkdown.ToArray();

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var jsonString = JsonSerializer.Serialize(tilemapDetails, jsonOptions);

File.WriteAllText(tilemapDetailsPath, jsonString);


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
