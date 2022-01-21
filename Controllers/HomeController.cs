﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;

namespace ASP.NET_Core.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("NashTech/ListPersons")]
    

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Rookies(){
        return View("Privacy");
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
