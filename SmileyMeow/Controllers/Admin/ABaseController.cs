using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmileyMeow.Controllers.Admin;
[Authorize(Roles = "Admin,Supervisor")]
public class ABaseController : Controller
{
    
}
