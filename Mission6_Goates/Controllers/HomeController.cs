using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Goates.Models;

namespace Mission6_Goates.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }
}