using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Hamilton.Models;
using System.Linq;

namespace Mission6_Hamilton.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        // 1) Home Page
        public IActionResult Index()
        {
            return View();
        }

        // 2) "Get to Know Joel" Page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        public IActionResult AddMovie(int? id)
        {
            ViewBag.Categories = _context.Categories.ToList(); // Pass categories to the view

            if (id == null || id == 0)
            {
                return View(new Movie());
            }

            var movie = _context.Movies
                .Where(m => m.MovieId == id)
                .Select(m => new Movie
                {
                    MovieId = m.MovieId,
                    Title = m.Title ?? "No Title Available",
                    Year = m.Year,
                    Director = m.Director ?? "Unknown Director",
                    Rating = m.Rating ?? "Not Rated",
                    Edited = m.Edited,
                    LentTo = m.LentTo ?? "N/A",
                    CopiedToPlex = m.CopiedToPlex,
                    Notes = m.Notes ?? "",
                    CategoryId = m.CategoryId
                }).FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    // New movie
                    _context.Movies.Add(movie);
                }
                else
                {
                    // Update existing movie
                    var existing = _context.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
                    if (existing == null)
                    {
                        return NotFound();
                    }

                    // Update properties
                    existing.Title = movie.Title ?? "Unknown Title";
                    existing.Year = movie.Year;
                    existing.Director = movie.Director ?? "Unknown Director";
                    existing.Rating = movie.Rating ?? "Not Rated";
                    existing.Edited = movie.Edited;
                    existing.LentTo = movie.LentTo ?? "N/A";
                    existing.CopiedToPlex = movie.CopiedToPlex;
                    existing.Notes = movie.Notes ?? "";
                }

                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // Log validation errors for debugging
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine("Validation Error: " + error.ErrorMessage);
            }

            return View(movie);
        }


        public IActionResult MovieList()
        {
            try
            {
                var movies = _context.Movies
                    .Select(movie => new Movie
                    {
                        MovieId = movie.MovieId,
                        Title = movie.Title ?? "No Title Available",
                        Year = movie.Year,
                        Director = movie.Director ?? "Unknown Director",
                        Rating = movie.Rating ?? "Not Rated",
                        Edited = movie.Edited,
                        LentTo = movie.LentTo ?? "N/A",
                        CopiedToPlex = movie.CopiedToPlex,
                        Notes = movie.Notes ?? ""
                    }).ToList();

                return View(movies);
            }
            catch (Exception ex)
            {
                // Log the actual error message for better debugging
                return Content("Error: " + ex.Message);
            }
        }



        // 6) Delete Movie (POST) - Called from a JavaScript confirmation popup
        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return Json(new { success = false, message = "Movie not found." });
            }

            try
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return Json(new { success = true, message = "Movie successfully deleted." });
            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = $"Error deleting movie: {ex.Message}" });
            }
        }
    }
}
