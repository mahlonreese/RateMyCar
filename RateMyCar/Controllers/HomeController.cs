using Microsoft.AspNetCore.Mvc;
using RateMyCar.Models;
using System.Diagnostics;
using RateMyCar.Data;
using Microsoft.EntityFrameworkCore;

namespace RateMyCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarDbContext _context;

        public HomeController(ILogger<HomeController> logger, CarDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // home page (all reviews)
        public IActionResult Index()
        {

            List<Review> reviews = _context.Reviews.ToList();
            foreach (Review review in reviews)
            {
                review.Car = _context.Cars.FirstOrDefault(c => c.CarId == review.CarId);
            }
            return View(reviews);
        }

        // my reviews
        [HttpGet("/myreviews/{user_id}")]
        public IActionResult MyReviews(int user_id)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserId == user_id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(user);
            }
        }

        // add review
        [HttpGet("/addreview")]
        public IActionResult AddReview()
        {
            return View();
        }

        // when the submit button in add review is clicked
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                // find the car in the database with those properties
                Car reviewedCar = _context.Cars.FirstOrDefault(u => u.Make == review.Car.Make && u.Model == review.Car.Model && u.Year == review.Car.Year);

                review.Car = reviewedCar;
                review.CarId = reviewedCar.CarId;

                User reviewer = _context.Users.FirstOrDefault(u => u.Email == review.User.Email);

                review.User = reviewer;
                review.UserId = reviewer.UserId;

                // Save the review to the database
                _context.Reviews.Add(review);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(review);
        }



        // car details
        [HttpGet("/cars/{car_id}")]
        public IActionResult CarDetails(int car_id)
        {
            Car car = _context.Cars.FirstOrDefault(c => c.CarId == car_id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return View(car);
            }
        }

        public IActionResult ReadMore(int id)
        {
            var review = _context.Reviews.Include(r => r.Car).Include(r => r.User).FirstOrDefault(r => r.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }


        [HttpGet("/searchcars")]
        public IActionResult SearchCars(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }

            // Search for cars matching the query
            var matchingCars = _context.Cars
                .Where(c => c.Make.Contains(query) || c.Model.Contains(query))
                .Include(c => c.Reviews) // Optionally include reviews
                .ToList();

            if (!matchingCars.Any())
            {
                return NotFound("No cars found matching your search.");
            }

            ViewData["Title"] = "Search Results";
            return View("SearchResults", matchingCars); // Use a new view to display results
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
