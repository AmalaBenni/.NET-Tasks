using Microsoft.AspNetCore.Mvc;
using StudentRecordMVC.Models;
using StudentRecordMVC.Helpers;

namespace StudentRecordMVC.Controllers
{
    public class StudentController : Controller
    {
       
        public StudentController() { }

      
        public IActionResult Index()
        {
            var students = FileHelper.ReadAll();  
            return View(students);
        }

    
        public IActionResult Create()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid) return View(student);

            var existing = FileHelper.FindByRoll(student.RollNumber);  // Updated
            if (existing != null)
            {
                ModelState.AddModelError("RollNumber", "A student with this roll number already exists.");
                return View(student);
            }

            FileHelper.AddStudent(student);  // Updated
            return RedirectToAction(nameof(Index));
        }

        // Show search form
        public IActionResult Search()
        {
            return View();
        }

        // Handle search request
        [HttpPost]
        public IActionResult Search(string rollNumber)
        {
            if (string.IsNullOrWhiteSpace(rollNumber))
            {
                ModelState.AddModelError("", "Enter a roll number.");
                return View();
            }

            var student = FileHelper.FindByRoll(rollNumber.Trim()); 
            if (student == null) return View("NotFound", rollNumber.Trim());

            return View("Details", student);
        }

        // Show student details
        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var student = FileHelper.FindByRoll(id); 
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
