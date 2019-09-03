using System.Collections.Generic;
using System.Linq;

namespace Work_ShortestPathInArray.API
{
    public static class ArrayPathFinder
    {
        public static bool IsEndReachable(params int[] array) => FindShortestPath(array) != null;

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
