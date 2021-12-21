using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc_test.Models;

namespace mvc_test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

	[Route("")]
    public IActionResult Index(string tenantId, string message)
    {
        return Content("HOME");
    }

    [Route("{tennant}/{message}")]
    public IActionResult Log(Tennant tennant, string message)
    {
        return Content("Tenant " + tennant.ID + " said: " + message);
    }

    [HttpPost]
    [Route("{tennant}")]
    public IActionResult PostLog(Tennant tennant, string message)
    {
        return Log(tennant,message);
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
