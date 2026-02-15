using EmployeeManagement.API.Core.Entities;
using EmployeeManagement.API.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace EmployeeManagement.API.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;
        public DepartmentRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }
        public async Task<IReadOnlyList<Department>> GetAllAsync()
        {
            var departments = new List<Department>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT DepartmentId, DepartmentName FROM Departments", connection);
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var department = new Department
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                departments.Add(department);
            }
            return departments;
        }
    }
}
