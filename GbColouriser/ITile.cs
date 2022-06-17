using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public interface ITile
    {
        Point Coordinate { get; }
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/indexers-in-interfaces
        Color this[int x, int y] { get; }

        HashSet<Color> Colours { get; }

        int ColourHash { get; }
    }
}
