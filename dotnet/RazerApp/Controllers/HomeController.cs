using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazerApp.Models;

namespace RazerApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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
    public IActionResult MyPage()
    {
        ViewBag.Message = "Hello, World!";
        ViewBag.Date = DateTime.Now;
        return View();
    }
    public IActionResult MyPage2(int number, string name, string? other)
    {
        ViewBag.Message = $"Number: {number}, Name: {name}, Other: {other}";
        ViewBag.Date = DateTime.Now;
        return View("MyPage");
    }
}
