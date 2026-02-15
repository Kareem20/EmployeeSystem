namespace EmployeeManagement.API.Core.Entities
{
    public class EmployeeJob
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Salary { get; set; }
        public Department Department { get; set; } = null!;
    }
}
