using Microsoft.AspNetCore.Mvc;
using SerializationMVC.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SerializationMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly string dataFolder;   //store the path of app_data
        private readonly string xmlFilePath;

        public EmployeesController()
        {
            
            dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            if (!Directory.Exists(dataFolder)) Directory.CreateDirectory(dataFolder); //if not exist app_data it will create 
            xmlFilePath = Path.Combine(dataFolder, "employees.xml");
        }

        // Show deserialized employees on page load
        public IActionResult Index()
        {
            var employees = new List<Employee>(); // mt 

            if (System.IO.File.Exists(xmlFilePath))  //check xml
            {
                using (var fs = new FileStream(xmlFilePath, FileMode.Open)) //m-file open
                {
                    var serializer = new XmlSerializer(typeof(List<Employee>));
                    employees = (List<Employee>)serializer.Deserialize(fs);
                }
            }

            return View(employees); 
        }

       
        [HttpPost]
        public IActionResult CreateAndSerialize()
        {
            var employees = new List<Employee>
            {
                new Employee{ Id=1, Name="Ruksana", Department="HR", Salary=50000 },
                new Employee{ Id=2, Name="Aswin", Department="IT", Salary=60000 },
                new Employee{ Id=3, Name="Nazrin", Department="Finance", Salary=55000 },
                new Employee{ Id=4, Name="Amala", Department="IT", Salary=40000 },
                new Employee{ Id=5, Name="Jincy", Department="IT", Salary=35000 },
            };

            using (var fs = new FileStream(xmlFilePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Employee>));
                serializer.Serialize(fs, employees);   //convert obj to xml
            }

            TempData["Message"] = "Employees serialized to employees.xml successfully!";
            return View("Index", new List<Employee>());
        }

       
        [HttpPost]
        public IActionResult DeserializeEmployees()
        {
            var employees = new List<Employee>();

            if (System.IO.File.Exists(xmlFilePath))
            {
                using (var fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(List<Employee>));
                    employees = (List<Employee>)serializer.Deserialize(fs);
                }

                TempData["Message"] = "Employees deserialized from XML successfully!";
            }
            else
            {
                TempData["Message"] = "No XML file found. Please serialize first.";
            }

            return View("Index", employees);
        }
    }
}