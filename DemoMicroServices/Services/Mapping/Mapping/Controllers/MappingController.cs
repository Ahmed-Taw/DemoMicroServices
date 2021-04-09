using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingController : ControllerBase
    {
        // GET: api/<MappingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MappingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MappingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

       
    }
}
