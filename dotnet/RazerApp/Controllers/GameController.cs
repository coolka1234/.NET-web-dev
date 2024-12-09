
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazerApp.Models;

namespace RazerApp.Controllers;

public class GameController: Controller
{
    static int number=10;
    static int numberMax=15;
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
    public IActionResult Game()
    {
        ViewBag.Counter = counter;
        ViewBag.Result = "Try to guess!";
        return View();
    }  
    // public IActionResult Set(int n)
    // {
    //     number = n;
    //     if(n < 1)
    //     {
    //         number = 1;
    //     }
    //     var random= new Random();
    //     guess = random.Next(0, n-1);
    //     return View("Game");
    // }
    public IActionResult Draw()
    {
        var random= new Random();
        guess = random.Next(number, numberMax-1);
        return View("Game");
    }
    public IActionResult Guess(int n)
    {
        if(n == guess)
        {
            ViewBag.GoodResult = "Correct!";
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
        return View("Game");
    }
    public IActionResult SetDraw(int n){
        Set(0,n, n+5);
        Draw();
        return View("Game");
    }
    public IActionResult Set(int? n,int? low, int? high){
        if(n != null){
            number = 0;
            numberMax = (int)number+5;
            return View("Game");
        }
        if(low == null || high == null){
            return View("Game");
        }
        else{
            number = (int)low;
            numberMax = (int)high;
            return View("Game");
        }
    }
}