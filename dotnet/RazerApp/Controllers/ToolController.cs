
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazerApp.Models;

namespace RazerApp.Controllers;

public class ToolController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Solve()
    {
        return View();
    }
    public IActionResult Solve2(int a, int b, int c)
    {
        int delta = b * b - 4 * a * c;
        if (delta>0)
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            ViewBag.Message = $"x1 = {x1}, x2 = {x2}";
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            ViewBag.Message = $"x = {x}";
        }
        else
        {
            ViewBag.Message = "No solution";
        }
        return View("Solve");
    }
}