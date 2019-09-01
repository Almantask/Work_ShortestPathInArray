using Work_ShortestPathInArray.API.Tests.Input;
using Xunit;

namespace Work_ShortestPathInArray.API.Tests
{
    public class ReachingEnd
    {
        [Theory]
        [MemberData(nameof(ArrayPaths.OneShortest), MemberType = typeof(ArrayPaths))]
        [MemberData(nameof(ArrayPaths.MultipleShortest), MemberType = typeof(ArrayPaths))]
        [MemberData(nameof(ArrayPaths.TooSmall), MemberType = typeof(ArrayPaths))]
        public void Path_IsReachable_True(params int[] stepsAhead)
        {
            var isEndReached = ArrayPathFinder.IsEndReachable(stepsAhead);
            Assert.True(isEndReached);
        }

        [Theory]
        [MemberData(nameof(ArrayPaths.Unreachable), MemberType = typeof(ArrayPaths))]
        public void Path_IsReachable_False(params int[] stepsAhead)
        {
            var isEndReached = ArrayPathFinder.IsEndReachable(stepsAhead);
            Assert.False(isEndReached);
        }
    }
}
