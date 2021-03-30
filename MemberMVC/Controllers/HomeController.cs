using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework_2021_03_25.Models;
using Microsoft.AspNetCore.Http;
using Homework_2021_03_25.Filters;
using MemberMVC.Services;

namespace Homework_2021_03_25.Controllers
{
    public class HomeController : Controller
    {
        public readonly MemberMVCContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MemberMVCContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAuthenticate(String username, String password)
        {
            LoginService loginService = new();
            User user = loginService.Authenticate(_context, username, password);
            if (user == null) {
                return RedirectToAction("Login");
            }
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("role", user.Role.Name);
            return RedirectToAction("Index", "Home");
        }
        [AuthorizeAtrribute("User")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
