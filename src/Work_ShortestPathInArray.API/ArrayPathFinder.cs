using System.Collections.Generic;
using System.Linq;

namespace Work_ShortestPathInArray.API
{
    public static class ArrayPathFinder
    {
        public static bool IsEndReachable(params int[] stepsAhead)
        {
            const int minimumPathLenght = 2;
            bool isEndMatchingStart = stepsAhead.Length < minimumPathLenght;
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

        public static IEnumerable<int> FindShortestPath(params int[] array)
        {
            var optimalPath = new List<int>();
            var pathEnd = array.Length - 1;
            var currentIndex = 0;

            if (pathEnd <= currentIndex) return optimalPath;

            optimalPath.Add(currentIndex);
            while(currentIndex < pathEnd)
            {
                var currentStepsAhead = array[currentIndex];
                if (currentStepsAhead == 0) return null;

                var isEndReachable = currentIndex + currentStepsAhead >= pathEnd;
                if (isEndReachable) return optimalPath;

                var nextOptimalIndex = currentIndex + 1;
                var distanceFromPrevious = 0;
                for (var forward = 1; forward <= currentStepsAhead; forward++)
                {
                    var nextOptimalSteps = array[nextOptimalIndex]; 
                    var nextIndex = currentIndex + forward;
                    var nextAhead = array[nextIndex];
                    var isNextShortcut = nextAhead >= nextOptimalSteps 
                                         && forward > distanceFromPrevious;
                    if (!isNextShortcut) continue;

                    nextOptimalIndex = nextIndex;
                    distanceFromPrevious = forward;
                }

                optimalPath.Add(nextOptimalIndex);
                currentIndex = nextOptimalIndex;
            }

            return optimalPath;
        }

    }
}