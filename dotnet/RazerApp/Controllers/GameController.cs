
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazerApp.Models;

namespace RazerApp.Controllers;

public class GameController: Controller
{
    static int number=10;
    static int guess=0;
    static int counter=0;
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Set(int n)
    {
        number = n;
        var random= new Random();
        guess = random.Next(0, n-1);
        return View();
    }
    public IActionResult Draw()
    {
        var random= new Random();
        guess = random.Next(0, number-1);
        return View();
    }
    public IActionResult Guess(int n)
    {
        if(n == guess)
        {
            ViewBag.Result = "Correct!";
            counter=0;
        }
        else if(n < guess)
        {
            ViewBag.Result = "Too small!";
            counter++;
        }
        else
        {
            ViewBag.Result = "Too large!";
            counter++;
        }
        ViewBag.Counter = counter;
        return View();
    }
}