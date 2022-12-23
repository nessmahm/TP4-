using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4_.Data;
using TP4_.Models;
using TP4_.Data.Repository;

namespace TP4_.Controllers
{
    public class HomeController : Controller
    {
        UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
        StudentRepository studentRepository = new StudentRepository();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var students = studentRepository.GetAll();
            foreach (Student student in students)
            Debug.WriteLine(student);
            ViewBag.students = students;
            return View();
        }
        [HttpGet("/course")]
        public IActionResult Course()
        {
            ViewBag.courses = studentRepository.GetCourses(); 
            return View();
        }

        [HttpGet("/student/{course}")]
        public IActionResult Student(string course)
        {
            ViewBag.students = studentRepository.GetByCourse(course);


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}