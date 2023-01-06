using Microsoft.AspNetCore.Mvc;

namespace SmileyMeow.Controllers;
public class APersonPropsController : Controller
{
    private readonly ILogger<APersonPropsController> _logger;

    public APersonPropsController(ILogger<APersonPropsController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }


    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
