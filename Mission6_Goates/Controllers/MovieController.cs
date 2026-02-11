using Microsoft.AspNetCore.Mvc;
using Mission6_Goates.Models;

namespace Mission6_Goates.Controllers;

public class MovieController : Controller
{
    private MovieDbContext _context;

    public MovieController(MovieDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return RedirectToAction("Confirmation");
        }

        return View(response);
    }
    public IActionResult Confirmation()
    {
        return View();
    }
}