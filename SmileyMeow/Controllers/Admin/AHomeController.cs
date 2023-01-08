using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmileyMeow.Controllers.Admin;

namespace SmileyMeow.Controllers.AdminControllers;

public class AHomeController : ABaseController
{
    private readonly ILogger<AHomeController> _logger;

    public AHomeController(ILogger<AHomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
