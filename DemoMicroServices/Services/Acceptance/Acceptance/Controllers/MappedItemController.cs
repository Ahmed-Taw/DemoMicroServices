using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acceptance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappedItemController : ControllerBase
    {

        public MappedItemController()
        {

        }
        //[Route("/MappedItems")]
        //[HttpGet]
        //public IEnumerable<MappedItem> GetMappedItems()
        //{
        //    return new List<MappedItem>();
        //}
    }
}
