using System.Collections.Generic;

namespace Work_ShortestPathInArray.API.Tests.Input
{
    public static class ArrayPathOutcomes
    {
        public static IList<object[]> TooManySteps
        {
            get
            {
                var input = ArrayPaths.MoreThanEnoughSteps;

                return new List<object[]>
                {
                    new object[] {new []{0}, input[0]},
                    new object[] {new []{0, 1, 3}, input[1]},
                    new object[] {new []{0}, input[2]}
                };
            }
        }

        public static IList<object[]> OneShortest
        {
            get
            {
                var input = ArrayPaths.OneShortest;

                return new List<object[]>
                {
                    new object[] {new []{0}, input[0]},
                    new object[] {new []{0}, input[1]},
                    new object[] {new []{0, 1, 3}, input[2]}
                };
            }
        }

        public static IList<object[]> MultipleShortest
        {
            get
            {
                var input = ArrayPaths.MultipleShortest;

                return new List<object[]>
                {
                    new object[] {new []{0, 1}, input[0]},
                    new object[] {new []{0, 1, 3}, input[1]},
                    new object[] {new [] {0, 1, 2}, input[2]},
                    new object[] {new [] {0, 1, 2, 8, 14, 20, 26 ,32}, input[3]}
                };
            }
        }

        public static IList<object[]> TooSmall
        {
            get
            {
                var input = ArrayPaths.TooSmall;

                return new List<object[]>
                {
                    new object[] {new int[]{}, input[0]},
                    new object[] {new int[]{}, input[1]},
                    new object[] {new int[]{}, input[2]}
                };
            }
        }
    }
}
