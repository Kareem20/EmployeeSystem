namespace EmployeeManagement.API.Application.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
