namespace EmployeeManagement.API.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public Gender Gender { get; set; } = null!;
        public EmployeeJob Job { get; set; } = null!;
    }
}
