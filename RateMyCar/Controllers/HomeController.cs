using Microsoft.AspNetCore.Mvc;
using RateMyCar.Models;
using System.Diagnostics;
using RateMyCar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var userId = HttpContext.Session.GetInt32("UserId");

            // Check if the UserId is null
            if (userId == null)
            {
                // Display an error message if the UserId is null
                ModelState.AddModelError(string.Empty, "You must be logged in to add a review.");
                return View(); // Return the view with the review model to display the error
            }

            List<Car> cars = _context.Cars.ToList();
            List<User> users = _context.Users.ToList();

            var carUser = new {cars = cars, users = users};

            return View(carUser);
        }

        // when the submit button in add review is clicked
        [HttpPost]
        public IActionResult AddReview(NewReview review)
        {
            Console.WriteLine(JsonConvert.SerializeObject(review));

            //if (ModelState.IsValid)
            //{
                // find the car in the database with those properties
            //    Car reviewedCar = _context.Cars.FirstOrDefault(u => u.CarId == review.CarId);

            //    review.Car = reviewedCar;
            //    review.CarId = reviewedCar.CarId;

            //    User reviewer = _context.Users.FirstOrDefault(u => u.Email == review.User.Email);

            //    review.User = reviewer;
            //    review.UserId = reviewer.UserId;

            //    // Save the review to the database
            //    _context.Reviews.Add(review);
            //    _context.SaveChanges();

            //    return RedirectToAction(nameof(Index));
            //}

            var newReviewId = _context.Reviews.Max(r => r.ReviewId) + 1;

            var userId = HttpContext.Session.GetInt32("UserId");

            // Check if the UserId is null
            if (userId == null)
            {
                // Display an error message if the UserId is null
                ModelState.AddModelError(string.Empty, "You must be logged in to add a review.");
                return View(review); // Return the view with the review model to display the error
            }

            var newReview = new Review
            {
                ReviewId = newReviewId,
                Rating = review.Rating,
                Comments = review.Comments,
                PhotoUrl = review.PhotoUrl,
                DatePosted = new DateOnly(2024, 10, 11),
                UserId = (int) userId,
                CarId = review.CarId
            };

            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult EditReview(int ReviewId, string ReviewText, string ReviewPhoto, int Rating)
        {
            // Fetch the review from the database using the ReviewId
            var review = _context.Reviews.Find(ReviewId);
            if (review != null)
            {
                review.Comments = ReviewText;
                review.PhotoUrl = ReviewPhoto;
                review.Rating = Rating;
                _context.SaveChanges();
            }

            return RedirectToAction("ReadMore", new { id = ReviewId });
        }

        [HttpPost]
        public IActionResult DeleteReview(int ReviewId)
        {
            var review = _context.Reviews.Find(ReviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        //[HttpGet("/adduser")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return Redirect("/");
            }

            return Redirect("/");
        }

        // GET: Home/Login
        //[HttpGet("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(usr => usr.Username == model.Username && usr.Password == model.Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Full Name", user.Fullname.ToString());
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Index", "Home");
            }

            // show error if null
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);

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


        // GET: /search
        [HttpGet("/search")]
        public IActionResult Search()
        {
            var cars = _context.Cars.ToList(); // Get all cars for the dropdown
            var carList = cars.Select(c => new
            {
                CarId = c.CarId,
                DisplayText = $"{c.Make} {c.Model}"
            }).ToList();

            ViewBag.Cars = new SelectList(carList, "CarId", "DisplayText"); // Use the new list
            return View();

            //ViewBag.Cars = new SelectList(cars, "CarId", "Make", "Model"); // Create a SelectList for the dropdown
            //return View();
        }

        // POST: /search
        [HttpPost("/search")]
        public IActionResult Search(int carId)
        {
            var reviews = _context.Reviews
                .Include(r => r.Car)
                .Include(r => r.User)
                .Where(r => r.CarId == carId)
                .ToList();

            if (!reviews.Any())
            {
                ViewData["Message"] = "No reviews found for the selected car.";
                return View("SearchResults", new List<Review>());
            }

            ViewData["Title"] = "Search Results";
            return View("SearchResults", reviews);
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
