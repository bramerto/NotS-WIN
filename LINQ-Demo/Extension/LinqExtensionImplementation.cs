using System;
using System.Collections.Generic;

namespace LINQ_Demo.Extension
{
    public static class LinqExtensionImplementation
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Console.WriteLine("Own Where implementation");
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Console.WriteLine("Own Select implementation");
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Console.WriteLine("Own 'Any' implementation");
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
