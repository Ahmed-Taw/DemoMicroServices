using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formulary.Models;

namespace Formulary.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormularyController : ControllerBase
    {
       [Route("Formularies")]
       [HttpGet]
       public IEnumerable<FormularyModel> GetFormularies()
        {
            return new List<FormularyModel>();
        }
    }
}
