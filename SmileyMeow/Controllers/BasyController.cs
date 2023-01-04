using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmileyMeow.Controllers;
public class BasyController : Controller
{
    public ActionResult UnderMaintenance() {
        
        return View();
    }
    public int ReturnLoggedUserId() {
        int loggedUserId = Convert.ToInt32(User.FindFirst(a => a.Type == ClaimTypes.Sid)?.Value);
        return loggedUserId;
    }

    
}
