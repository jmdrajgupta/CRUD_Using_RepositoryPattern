using CRUD_Using_Repository.Models; // Importing the namespace for models, specifically to access the ErrorViewModel class
using Microsoft.AspNetCore.Mvc;      // Importing ASP.NET Core MVC library to access controller and related functionality
using System.Diagnostics;           // Importing the System.Diagnostics namespace to access Activity for tracking request IDs

namespace CRUD_Using_Repository.Controllers
{
    // HomeController: This class handles incoming requests related to the home page and other static content (like privacy policy).
    public class HomeController : Controller
    {
        // _logger: A private readonly field used for logging messages (info, warnings, errors). ILogger is dependency injected.
        private readonly ILogger<HomeController> _logger;

        // Constructor: Dependency injection of the ILogger interface to log actions performed within this controller.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Index Action: This method handles GET requests to the default page of the application (e.g., /Home/Index or just /). 
        // It returns the "Index" view (Index.cshtml).
        public IActionResult Index()
        {
            return View(); // Renders the "Index" view
        }

        // Privacy Action: This method handles requests for the Privacy Policy page (/Home/Privacy).
        // It returns the "Privacy" view (Privacy.cshtml).
        public IActionResult Privacy()
        {
            return View(); // Renders the "Privacy" view
        }

        // Error Action: This method handles errors and returns an error view (Error.cshtml). 
        // The [ResponseCache] attribute prevents caching of the error page by specifying the cache behavior.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Creates an instance of the ErrorViewModel, passing the current request's ID (or TraceIdentifier if Activity is null).
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
