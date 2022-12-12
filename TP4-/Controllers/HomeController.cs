using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4_.Data;
using TP4_.Models;

namespace TP4_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Student> students = universityContext.Student.ToList();
            foreach (Student student in students)
            Debug.WriteLine(student);
            ViewBag.students = students;
            return View();
        }
        [HttpGet("/course")]
        public IActionResult Course()
        {
            var courses = universityContext.Student.Select(x => x.Course).Distinct().ToList();
            ViewBag.courses = courses;
            return View();
        }
        [HttpGet("/student/{course}")]
        public IActionResult Student(string course)
        {
            List<Student> students = universityContext.Student.Where(s => s.Course.ToUpper() == course.ToUpper()).ToList();
            ViewBag.students = students;


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}