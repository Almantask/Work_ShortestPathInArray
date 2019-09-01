using Work_ShortestPathInArray.API.Exceptions;
using Work_ShortestPathInArray.API.Tests.Input;
using Xunit;

namespace Work_ShortestPathInArray.API.Tests
{
    public class ShortestPath
    {
        [Theory]
        [MemberData(nameof(ArrayPaths.Unreachable), MemberType = typeof(ArrayPaths))]
        public void Path_NotFound_Throws(params int[] stepsAhead)
        {
            Assert.Throws<UnreachablePathException>(
                () => ArrayPathFinder.FindShortestPath(stepsAhead));
        }

        [Theory]
        [MemberData(nameof(ArrayPathOutcomes.OneShortest), MemberType = typeof(ArrayPathOutcomes))]
        [MemberData(nameof(ArrayPathOutcomes.MultipleShortest), MemberType = typeof(ArrayPathOutcomes))]
        [MemberData(nameof(ArrayPathOutcomes.TooSmall), MemberType = typeof(ArrayPathOutcomes))]
        [MemberData(nameof(ArrayPathOutcomes.TooManySteps), MemberType = typeof(ArrayPathOutcomes))]
        public void Path_Found_Shortest(int[] expectedPath, int[] stepsAhead)
        {
            var shortestPath = ArrayPathFinder.FindShortestPath(stepsAhead);
            Assert.Equal(expectedPath, shortestPath);
        }

    }
}
