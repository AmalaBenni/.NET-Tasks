using System;
using System.Collections.Generic;
using System.Linq;

class Student 
{
    public string Name;
    public int Age;

}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Amala", Age = 22 },
            new Student { Name = "Ruksana", Age = 24 },
            new Student { Name = "Jincy", Age = 23 },
            new Student { Name = "Ammu", Age = 18  }
        };

       
        Console.Write("Enter maximum age: ");
        int maxAge = int.Parse(Console.ReadLine());
      
        var filtered = students.Where(s => s.Age <= maxAge);
        Console.WriteLine("Students : ");
        foreach (var s in filtered)
        {
            Console.WriteLine(s.Name + " - " + s.Age);
        }
    }
}