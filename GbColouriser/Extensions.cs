using System.Drawing;

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
        public static IEnumerable<T> ToIEnumerable<T>(this T[,] twoDimensionalArray)
        {
            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    yield return twoDimensionalArray[i, j];
                }
            }
        }

        public static IEnumerable<((int x, int y) coordinates, T item)> ToIEnumerableWithCoords<T>(this T[,] twoDimensionalArray)
        {
            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    yield return ((i, j), twoDimensionalArray[i, j]);
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
