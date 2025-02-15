using Microsoft.AspNetCore.Mvc;
using Mission6_Hamilton.Models;

namespace Mission6_Hamilton.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }
        
        // GET: Movies/Create
        [HttpGet]
      
        // POST: Movies/Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            // Check model validation
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                // Optionally redirect to a "Success" page or list page
                return RedirectToAction("Index", "Home");
            }

            return View(movie); // Return the same view if invalid
        }
    }
}