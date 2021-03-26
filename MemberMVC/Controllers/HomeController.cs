using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework_2021_03_25.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Homework_2021_03_25.Filters;

namespace Homework_2021_03_25.Controllers
{
    public class HomeController : Controller
    {
        public static List<User> userList = new();
        public static List<Role> roleList = new();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            roleList.Add(new Role() {Id = 1, Name = "Admin"});
            roleList.Add(new Role() {Id = 2, Name = "User"});
            userList.Add(new User() {Id = 1, Username = "Admin", Password  = "1", RoleId = 1});
            userList.Add(new User() {Id = 2, Username = "User", Password  = "2", RoleId = 2});
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
            User user = Models.User.Authenticate(username, password);
            if (user == null) {
                return RedirectToAction("Login");
            }
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("role", user.GetRole().Name);
            return Redirect("/");
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
