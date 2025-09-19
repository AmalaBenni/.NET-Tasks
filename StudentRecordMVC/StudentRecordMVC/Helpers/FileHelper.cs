using StudentRecordMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentRecordMVC.Helpers
{
    public static class FileHelper
    {
        
        private static string GetFilePath()
        {
            var dir = "C:/Users/WIIS/Desktop/App_Data";

           
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var path = Path.Combine(dir, "students.txt");

           
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }

            return path;
        }

      
        public static void AddStudent(Student s)
        {
            var path = GetFilePath();
            var line = $"{s.RollNumber}|{s.Name}|{s.Marks}";
            File.AppendAllLines(path, new[] { line });
        }

     
        public static List<Student> ReadAll()
        {
            var path = GetFilePath();
            var result = new List<Student>();

            foreach (var raw in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;

                var parts = raw.Split('|');
                if (parts.Length < 3) continue;

                int marks = 0;
                int.TryParse(parts[2], out marks);

                result.Add(new Student
                {
                    RollNumber = parts[0].Trim(),
                    Name = parts[1].Trim(),
                    Marks = marks
                });
            }

            return result;
        }

       
        public static Student FindByRoll(string roll)
        {
            List<Student> students = ReadAll();
            return students.FirstOrDefault(s => s.RollNumber == roll);
        }
    }
}
