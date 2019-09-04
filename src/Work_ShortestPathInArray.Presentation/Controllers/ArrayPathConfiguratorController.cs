using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Work_ShortestPathInArray.API;

namespace Work_ShortestPathInArray.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ArrayPathConfiguratorController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<int> FindShortestPath(int[] array)
        {
            return ArrayPathFinder.FindShortestPath(array);
        }

        [HttpGet("[action]")]
        public bool IsEndReachable(int[] array)
        {
            return ArrayPathFinder.IsEndReachable(array);
        }
    }
}
