using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmileyMeow.Controllers;
public class BasyController : Controller
{
    public ActionResult UnderMaintenance() {
        
        return View();
    }
}
