using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbColouriser
{
    public static class Extensions
    {
        //https://stackoverflow.com/a/13091986
        public static bool ContainsAll<T>(this IEnumerable<T> containingList, IEnumerable<T> lookupList)
        {
            return !lookupList.Except(containingList).Any();
        }

        // https://docs.microsoft.com/en-us/archive/msdn-magazine/2017/june/essential-net-custom-iterators-with-yield
        public static IEnumerable<ITile> TileIterator<ITile>(this ITile[,] tileArray)
        {
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    yield return tileArray[i, j];
                }
            }
        }

        // https://www.nbdtech.com/Blog/archive/2008/04/27/calculating-the-perceived-brightness-of-a-color.aspx
        public static int GetPerceivedBrightness(this Color c)
        {
            return (int)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }
    }
}
