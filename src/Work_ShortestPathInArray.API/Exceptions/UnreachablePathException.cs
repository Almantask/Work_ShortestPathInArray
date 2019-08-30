using System;
using System.Collections.Generic;
using System.Text;

namespace Work_ShortestPathInArray.API.Exceptions
{
    public class UnreachablePathException: Exception
    {
        public UnreachablePathException():base("Unable to reach the end of array: ran out of steps")
        {
        }
    }
}
