//using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
   
    public class LoginController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            if (_userManager.Users != null)
            {
                var user = _userManager.Users;
            }

            return View();
        }
    }
}
