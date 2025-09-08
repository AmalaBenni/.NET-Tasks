namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }   // Required means caller must provide value
        public required string Email { get; set; }
        public required string Department { get; set; }
    }

}
