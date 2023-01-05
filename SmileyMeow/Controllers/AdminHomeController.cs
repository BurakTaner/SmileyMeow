using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmileyMeow.Controllers.AdminControllers;

public class AdminHomeController : Controller
{
    private readonly ILogger<AdminHomeController> _logger;

    public AdminHomeController(ILogger<AdminHomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
