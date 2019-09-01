using System;
using System.Collections;
using System.Collections.Generic;

namespace Work_ShortestPathInArray.API.Extensions
{
    public static class IListExtensions
    {
        public static IList<T> CloneWithAdded<T>(this IList<T> list, T value)
        {
            var clone = new List<T>(list) {value};

            return clone;
        }
    }
}
