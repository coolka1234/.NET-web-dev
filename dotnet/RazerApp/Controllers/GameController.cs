using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RazerApp.Models;

namespace RazerApp.Controllers;

public class GameController : Controller
{
    private const string NumberKey = "Number";
    private const string NumberMaxKey = "NumberMax";
    private const string GuessKey = "Guess";
    private const string CounterKey = "Counter";

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Game()
    {
        ViewBag.Counter = HttpContext.Session.GetInt32(CounterKey) ?? 0;
        ViewBag.Result = "Try to guess!";
        return View();
    }

    public IActionResult Draw()
    {
        var random = new Random();
        int number = HttpContext.Session.GetInt32(NumberKey) ?? 10;
        int numberMax = HttpContext.Session.GetInt32(NumberMaxKey) ?? 15;
        int guess = random.Next(number, numberMax - 1);
        HttpContext.Session.SetInt32(GuessKey, guess);
        return View("Game");
    }

    public IActionResult Guess(int n)
    {
        int guess = HttpContext.Session.GetInt32(GuessKey) ?? 0;
        int counter = HttpContext.Session.GetInt32(CounterKey) ?? 0;

        if (n == guess)
        {
            ViewBag.GoodResult = "Correct!";
            counter = 0;
        }
        else if (n < guess)
        {
            ViewBag.Result = "Too small!";
            counter++;
        }
        else
        {
            ViewBag.Result = "Too large!";
            counter++;
        }

        HttpContext.Session.SetInt32(CounterKey, counter);
        ViewBag.Counter = counter;
        return View("Game");
    }

    public IActionResult SetDraw(int n)
    {
        Set(0, n, n + 5);
        Draw();
        return View("Game");
    }

    public IActionResult Set(int? n, int? low, int? high)
    {
        if (n != null)
        {
            HttpContext.Session.SetInt32(NumberKey, 0);
            HttpContext.Session.SetInt32(NumberMaxKey, 5);
            return View("Game");
        }

        if (low == null || high == null)
        {
            return View("Game");
        }
        else
        {
            HttpContext.Session.SetInt32(NumberKey, (int)low);
            HttpContext.Session.SetInt32(NumberMaxKey, (int)high);
            return View("Game");
        }
    }
}