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

	[HttpPost]
	[Route("")]
	public IActionResult Index(string tenantId, string message)
	{
		// Usando o Logger para registrar um texto com formatação.
		_logger.LogInformation(0,null,"Executando post vindo de {}", tenantId);
		return Content("Index recebeu como id: " + tenantId + "\nMensagem: " + message);
	}

	// Rota para GET
	[Route("{tennant}/{message}")]
	public IActionResult Log(Tennant tennant, string message)
	{
		return Content("Tenant " + tennant.ID + " said: " + message);
	}

	// Rota para POST da mensagem, com o id do tennant na url
	[HttpPost]
	[Route("{tennant}")]
	public IActionResult PostLog(Tennant tennant, string message)
	{
		return Log(tennant,message);
	}

	//
	// Vestígios do template gerado pelo dotnet new:
	//

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
