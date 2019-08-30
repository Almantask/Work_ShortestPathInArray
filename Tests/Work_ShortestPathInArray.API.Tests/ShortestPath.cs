using System.Collections.Generic;
using Work_ShortestPathInArray.API.Exceptions;
using Xunit;

namespace Work_ShortestPathInArray.API.Tests
{
    public class ShortestPath
    {
        [Theory]
        [InlineData(1, 2, 0, 1, 0, 2, 0)]
        public void Path_NotFound_Throws(params int[] stepsAhead)
        {
            Assert.Throws<UnreachablePathException>(
                () => ArrayPathFinder.FindShortestPath(stepsAhead));
        }

        [Theory]
        [InlineData(new[] { 0, 1, 3 }, new [] {1, 2, 0, 3, 0, 2, 0})]
        [InlineData(new[] { 0, 1, 2 }, new[] {1, 2, 4, 3, 2, 2, 0})]
        public void Path_Found_Shortest(int[] expectedPath, int[] stepsAhead)
        {
            var shortestPath = ArrayPathFinder.FindShortestPath(stepsAhead);
            Assert.Equal(expectedPath, shortestPath);
        }
    }
}
