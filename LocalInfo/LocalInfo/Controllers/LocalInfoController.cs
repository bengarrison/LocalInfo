using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LocalInfo.Controllers
{
    [Route("api/[controller]")]
    public class LocalInfoController : Controller
    {
        // GET api/values
        [HttpGet]
        public object Get()
        {


            return new string[] { "value1", "145616519" };
        }
        
    }
}
