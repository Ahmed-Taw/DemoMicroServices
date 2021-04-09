using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebStatus.Models;

namespace WebStatus.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var basePath = _configuration["PATH_BASE"];
            return Redirect($"{basePath}/hc-ui");
        }

        [HttpGet("/Config")]
        public IActionResult Config()
        {
            var configurationValues = _configuration.GetSection("HealthChecksUI:HealthChecks")
                .GetChildren()
                .SelectMany(cs => cs.GetChildren())
                .Union(_configuration.GetSection("HealthChecks-UI:HealthChecks")
                .GetChildren()
                .SelectMany(cs => cs.GetChildren()))
                .ToDictionary(v => v.Path, v => v.Value);

            return View(configurationValues);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
