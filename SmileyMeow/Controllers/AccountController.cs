using SmileyMeow.Data;
using SmileyMeow.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SmileyMeow.ViewModels;
using VetClinicLibrary.User;
using VetClinicLibrary.Person;

namespace SmileyMeow.Controllers
{
    public class AccountController : BasyController
    {
        private readonly SmileyMeowDbContext _context;

        public AccountController(SmileyMeowDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            LoginViewModel x = new LoginViewModel();
            
            return View(x);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Emaill,Passwordd")] LoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identityy = null;
                bool isAuthenticated = false;
                Userr registeredUser = await _context.Userrs.Include(k => k.Rolee).FirstOrDefaultAsync(m => m.Emaill == userLogin.Emaill && m.Passwordd == userLogin.Passwordd);

                if (registeredUser == null)
                {
                    ModelState.AddModelError("", "Couldn't find the user.");
                    return View(userLogin);
                }

                identityy = new ClaimsIdentity
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,registeredUser.UserrId.ToString()),
                            new Claim(ClaimTypes.Email,registeredUser.Emaill),
                            new Claim(ClaimTypes.Role,registeredUser.Rolee.RName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                );

                isAuthenticated = true;

                if (isAuthenticated)
                {
                    var claimss = new ClaimsPrincipal(identityy);
                    var loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimss,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(15)
                        }

                        );

                    if (registeredUser.Rolee.RName == "Candidate")
                    {
                        return Redirect("~/Account/EmailApproveReminder");
                    }
                    else if (registeredUser.Rolee.RName == "PetParent")
                    {

                        return RedirectToAction("", "");
                    }
                    else if (registeredUser.Rolee.RName == "Admin")
                    {
                        return Redirect("~/AHome/");
                    }

                    else if (registeredUser.Rolee.RName == "Supervisor")
                    {
                        return Redirect("~/AHome/");
                    }

                    else
                    {
                        return Redirect("~/Home/");
                    }

                }
                return View();
            }
            return View(userLogin);
        }

        public async Task<IActionResult> Activation(string kkk)
        {
            string emaill = Criyptoo.Decrypted(kkk);

            Userr userr = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == emaill);
            userr.RoleeId = 6;
            _context.Userrs.Update(userr);
            await _context.SaveChangesAsync();

            return View();
        }



        [Authorize(Roles = "Candidate")]
        public IActionResult EmailApproveReminder()
        {
            return View();
        }

        public IActionResult Register()
        {
            RegisterViewModel userr = new ();
            return View(userr);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register([Bind("Emaill", "Passwordd", "ConfirmPasswordd")] RegisterViewModel registerViewModel)
        {
            Userr userr = new();
            userr.Emaill = registerViewModel.Emaill;
            userr.Passwordd = registerViewModel.Passwordd;
            userr.RoleeId = registerViewModel.RoleeId;


            if (ModelState.IsValid)
            {
                Userr selectedUserr = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == userr.Emaill);
                
                if (selectedUserr != null)
                {
                    ModelState.AddModelError("", "Email is already in use.");
                }
            }

            if (ModelState.IsValid)
            {
                await _context.Userrs.AddAsync(userr);
                await _context.SaveChangesAsync();

                EmailOperations.SendActivationMail(userr.Emaill);

                return RedirectToAction("Login", "Account");

            }

            return View(registerViewModel);
        }




        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("", "");
        }


    }
}
