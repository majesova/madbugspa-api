using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadBugAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    [ProducesResponseType(401, Type = typeof(string))]
    public class BugController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Post(/* ??*/){ //Dto
            return Ok();
        }

    }
}
