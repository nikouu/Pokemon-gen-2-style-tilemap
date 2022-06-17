using System.Drawing;

namespace GbColouriser
{
    public interface ITile
    {
        Point Coordinate { get; }
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/indexers-in-interfaces
        Color this[int x, int y] { get; }

        HashSet<Color> Colours { get; }
        Color[,] ColourMap { get; }

        int ColourHash { get; }
    }
}
