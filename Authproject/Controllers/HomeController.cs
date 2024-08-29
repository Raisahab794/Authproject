using Authproject.Areas.Identity.Data;
using Authproject.Models;
using Authproject.Areas.Identity.Data;
using Authproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Authproject.Controllers
{
    [Authorize] // This attribute will make sure that only authenticated users can access the HomeController
    public class HomeController : Controller // HomeController inherits from Controller
    {
        private readonly ILogger<HomeController> _logger;   // ILogger is a generic interface that logs messages
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View();
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
}