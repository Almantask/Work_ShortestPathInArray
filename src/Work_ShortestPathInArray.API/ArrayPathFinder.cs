using System.Collections.Generic;
using System.Linq;
using Work_ShortestPathInArray.API.Exceptions;
using Work_ShortestPathInArray.API.Extensions;

namespace Work_ShortestPathInArray.API
{
    public static class ArrayPathFinder
    {
        public static bool IsEndReachable(params int[] stepsAhead)
        {
            bool isEndMatchingStart = stepsAhead.Length < 2;
            return isEndMatchingStart || IsEndReachable(0, stepsAhead);
        }

        private static bool IsEndReachable(int startingIndex, params int[] array)
        {
            var stepsAhead = array[startingIndex];
            if (stepsAhead == 0) return false;

            var isEndReached = stepsAhead >= array.Length - startingIndex;
            if (isEndReached) return true;

            for (var option = 1; option <= stepsAhead; option++)
            {
                isEndReached = IsEndReachable(startingIndex + option, array);
                if (isEndReached) return true;
            }

            return false;
        }

        public static IEnumerable<int> FindShortestPath(params int[] stepsAhead)
        {
            var path = FindShortestPath(0, stepsAhead, new List<int>());
            if (path == null) throw new UnreachablePathException();

            return path;
        }

        private static IList<int> FindShortestPath(int startingIndex, int[] array, IList<int> path)
        {
            var stepsAhead = array[startingIndex];
            if (stepsAhead == 0) return null;

            var isEndReached = stepsAhead >= array.Length - startingIndex;
            if (isEndReached) return path;

            var newPath = path.CloneWithAdded(startingIndex);
            var foundPaths = new List<IList<int>>();
            for (var option = 1; option <= stepsAhead; option++)
            {
                var foundPath = FindShortestPath(startingIndex + option, array, newPath);
                if (foundPath != null)
                {
                    foundPaths.Add(foundPath);
                }
            }

            if (!foundPaths.Any()) return null;

            var shortestPath = foundPaths.OrderBy(p => p.Count).FirstOrDefault();

            return shortestPath;
        }

    }
}