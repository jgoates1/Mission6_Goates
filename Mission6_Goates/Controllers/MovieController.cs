using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories.OrderBy(x=>x.CategoryName)
            .ToList();
        return View(new Movie());
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

        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

        return View(response);
    }
    public IActionResult Confirmation()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieList()
    {
        var movies = _context.Movies.Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Single(y => y.MovieId == id);
        
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        
        return View("AddMovie", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();
            
            return RedirectToAction("MovieList");
        }
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        
        return View("AddMovie", updatedInfo);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(y => y.MovieId == id);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie recordToDelete)
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
}