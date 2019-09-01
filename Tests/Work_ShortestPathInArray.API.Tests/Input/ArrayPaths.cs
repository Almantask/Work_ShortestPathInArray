using System.Collections.Generic;

namespace Work_ShortestPathInArray.API.Tests.Input
{
    public static class ArrayPaths
    {
        public static IList<object[]> MoreThanEnoughSteps =>
            new List<object[]>
            {
                new object[] {2, 0},
                new object[] {1, 2, 0, 3, 0, 100, 0},
                new object[] {1000, 1000, 1000, 1000, 1000, 1000, 1000}
            };

        public static IList<object[]> OneShortest =>
            new List<object[]>
            {
                new object[] {1, 1},
                new object[] {1, 0},
                new object[] {1, 2, 0, 3, 0, 1, 0}
            };

        public static IList<object[]> MultipleShortest =>
            new List<object[]>
            {
                new object[] {2, 2, 1, 0},
                new object[] {1, 2, 2, 5, 4, 0, 0 ,0, 0 },
                new object[] {1, 3, 6, 5, 4, 0, 0 ,0, 0 },
                new object[] {1, 3, 6, 5, 4, 0, 0 ,0,
                    6, 5, 4, 0, 0 ,0,
                    6, 5, 4, 0, 0 ,0,
                    6, 5, 4, 0, 0 ,0,
                    6, 5, 4, 0, 0 ,0,
                    5, 4, 3, 0, 0 ,0}
            };

        public static IList<object[]> Unreachable =>
            new List<object[]>
            {
                new object[] {1, 2, 0, 1, 0, 2, 0},
                new object[] {0, 1},
                new object[] {0, 0},
                new object[] {0, 0, 0, 0 ,5}
            };

        public static IList<object[]> TooSmall =>
            new List<object[]>
            {
                new object[] {},
                new object[] {0},
                new object[] {1}
            };
    }
}
