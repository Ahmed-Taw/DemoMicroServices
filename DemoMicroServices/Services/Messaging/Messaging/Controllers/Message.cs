using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Message : ControllerBase
    {
        [HttpPost]
        public void Add([FromBody] string message)
        {

        }
    }
}
