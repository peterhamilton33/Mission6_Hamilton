using Microsoft.AspNetCore.Mvc;
using Mission6_Hamilton.Models;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Reuse AddMovie.cshtml for both adding and editing movies
        public IActionResult AddMovie(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Movie()); // Creating a new movie
            }

            var movie = _context.Movies
                .FirstOrDefault(m => m.MovieId == id); // Safer way to find movie

            if (movie == null)
            {
                return NotFound(); // Movie doesn't exist
            }

            return View(movie);
        }


        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0) // Adding a new movie
                {
                    _context.Movies.Add(movie);
                }
                else // Editing an existing movie
                {
                    _context.Movies.Update(movie);
                }

                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            return View(movie);
        }


        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .Select(m => new Movie
                {
                    MovieId = m.MovieId,
                    CategoryId = m.CategoryId,
                    Title = m.Title ?? "Unknown Title",
                    Year = m.Year,
                    Director = m.Director ?? "Unknown Director",
                    Rating = m.Rating ?? "Not Rated",
                    Edited = m.Edited,
                    LentTo = m.LentTo ?? "N/A",
                    CopiedToPlex = m.CopiedToPlex,
                    Notes = m.Notes ?? ""
                })
                .ToList();

            return View(movies);
        }

        [HttpPost]
        [Route("Home/DeleteMovie/{id}")]
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
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error deleting movie: {ex.Message}" });
            }
        }

    }
}
