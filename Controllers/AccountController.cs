using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTL_NMCNPM.Models;

namespace BTL_NMCNPM.Controllers;

public class AccountController : Controller
{
   

    public IActionResult Login()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Login(string Username, string Password)
    {
        if (Username == "admin" && Password == "123456")
        {
            return RedirectToAction("Index", "Home"); // Chuyển hướng sau khi đăng nhập thành công
        }
        ViewBag.Error = "Invalid username or password";
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
