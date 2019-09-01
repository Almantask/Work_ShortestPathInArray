using System.Collections.Generic;
using System.Linq;
using Work_ShortestPathInArray.API.Exceptions;
using Work_ShortestPathInArray.API.Extensions;

namespace Work_ShortestPathInArray.API
{
    public static class ArrayPathFinder
    {
        private const int MinimumPathSize = 2;

        // Should not be reused within pathfinding algorithm,
        // because it would cause reiterating the array.
        public static bool IsEndReachable(params int[] stepsAhead)
        {
            bool isEndMatchingStart = stepsAhead.Length < MinimumPathSize;
            return isEndMatchingStart || IsEndReachable(0, stepsAhead);
        }

        private static bool IsEndReachable(int startingIndex, params int[] array)
        {
            var stepsAhead = array[startingIndex];
            if (stepsAhead == 0) return false;

            var willReachEnd = stepsAhead >= array.Length - 1 - startingIndex;
            if (willReachEnd) return true;

            for (var option = 1; option <= stepsAhead; option++)
            {
                var isEndReached = IsEndReachable(startingIndex + option, array);
                if (isEndReached) return true;
            }

            return false;
        }

        public static IEnumerable<int> FindShortestPath(params int[] stepsAhead)
        {
            bool isEndMatchingStart = stepsAhead.Length < MinimumPathSize;
            if(isEndMatchingStart) return new List<int>();

            var path = FindShortestPath(0, stepsAhead, new List<int>());
            if (path == null) throw new UnreachablePathException();

            return path;
        }

        private static IList<int> FindShortestPath(int startingIndex, int[] array, IList<int> path)
        {
            var isEndReached = startingIndex == array.Length - 1;
            if (isEndReached) return path;

            var stepsAhead = array[startingIndex];
            if (stepsAhead == 0) return null;

            var newPath = path.CloneWithAdded(startingIndex);
            var foundPaths = new List<IList<int>>();
            for (var option = 1; option <= stepsAhead; option++)
            {
                var willBeOutOfBounds = option + startingIndex >= array.Length;
                if (willBeOutOfBounds) continue;

                var foundPath = FindShortestPath(startingIndex + option, array, newPath);
                if (foundPath == null) continue;

                foundPaths.Add(foundPath);
            }
            var shortestPath = foundPaths.OrderBy(p => p.Count).FirstOrDefault();

            return shortestPath;
        }
    }
}