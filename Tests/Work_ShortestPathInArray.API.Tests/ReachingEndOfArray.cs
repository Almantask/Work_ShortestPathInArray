using Xunit;

namespace Work_ShortestPathInArray.API.Tests
{
    public class ReachingEnd
    {
        [Theory]
        [InlineData(true, 1, 2, 0, 3, 0, 2, 0)]
        [InlineData(false, 1, 2, 0, 1, 0, 2, 0)]
        public void Path_IsReachable(bool expectedOutcome, params int[] stepsAhead)
        {
            var isEndReached = ArrayPathFinder.IsEndReachable(stepsAhead);
            Assert.Equal(expectedOutcome, isEndReached);
        }
    }
}
