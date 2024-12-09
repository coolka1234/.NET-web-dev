
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
        if(a==0){
            if(b==0){
                if(c==0){
                    ViewBag.AllSolution = "0=0";
                    return View("Solve");
                }
                else{
                    ViewBag.NoResult = "No solution";
                    return View("Solve");
                }
            }
            else{
                double x = -c / b;
                ViewBag.OneResult = $"x = {x}";
                return View("Solve");
            }
        }
        if (delta>0)
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            ViewBag.TwoResults = $"x1 = {x1}, x2 = {x2}";
        }
        else if (delta == 0)
        {
            if(a == 0)
            {
                ViewBag.AllSolution = "0=0";
                return View("Solve");
            }
            double x = -b / (2 * a);
            ViewBag.OneResult = $"x = {x}";
        }
        else
        {
            ViewBag.NoResult = "No solution";
        }
        return View("Solve");
    }
}