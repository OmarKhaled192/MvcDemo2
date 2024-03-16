using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using demo.Models;

namespace demo.Controllers
{
    public class MoviesController  : Controller
    {
        private readonly IConfiguration _configuration;

        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [HttpPost]
        // or
        //[AcceptVerbs("GET", "POST")]

        [ActionName("Index")]
        public string GetAllMovies()
        {
            return "All Movies";
        }

        // Action: Public Non-Static Object Member function



        public IActionResult GetMovie(int id, string name, Employee employee)
        
        {

            ContentResult result = new ContentResult();

            result.Content = $"<h2 style='background-color: red; text-align: center; color: green; width: 75% ;margin: auto ;padding: 10px; border : 1px solid blue; '>  your id is {id}, <br> your name is {name} </h2> ";

            result.ContentType = "text/html";
            //result.StatusCode = 404;
            return result;
            //return Content($"your id is {id}");
        }
        
        public IActionResult Hamada() { 
            BadRequestResult badRequest = new BadRequestResult();
            UnauthorizedResult unauthorized = new UnauthorizedResult(); 

            RedirectResult redirectResult = new RedirectResult("http://localhost:5003/Movies/Index");

            RedirectResult redirectResult2 = new RedirectResult($"{_configuration["BaseUrl"]}/Movies/Index");

            RedirectToActionResult redirectToActionResult = new RedirectToActionResult("GetMovie", "Movies", null); // null for empty Parameters
           
            
            RedirectToActionResult redirectToActionResult2 = new RedirectToActionResult(nameof(GetAllMovies), nameof(MoviesController), new {id = 12}); // null for empty Parameters

            RedirectToRouteResult redirectToRouteResult = new RedirectToRouteResult("Default", new {controller=nameof(MoviesController), action = nameof(GetMovie), id = 12 });

            return redirectToRouteResult;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ///ViewResult viewResult = new ViewResult();
            ///viewResult.ViewName = "Create";
            ///return viewResult;

            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            return new EmptyResult();
        }
    }
}
