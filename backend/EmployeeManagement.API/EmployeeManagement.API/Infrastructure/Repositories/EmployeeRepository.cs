using EmployeeManagement.API.Core.Entities;
using EmployeeManagement.API.Core.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeManagement.API.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;
        public EmployeeRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }
        public async Task CreateAsync(Employee employee)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("CreateEmployeeWithJob", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@GenderId", employee.Gender.Id);
                command.Parameters.AddWithValue("@DepartmentId", employee.Job.Department.Id);
                command.Parameters.AddWithValue("@JobTitle", employee.Job.Title);
                command.Parameters.AddWithValue("@Salary", employee.Job.Salary);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating the employee.", ex);
            }
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var employees = new List<Employee>();
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("GetEmployeesWithJobs", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString()!,
                        Address = reader["Address"] is DBNull ? string.Empty : reader["Address"].ToString(),
                        Gender = new Gender
                        {
                            Id = Convert.ToInt32(reader["GenderId"]),
                            Name = reader["GenderName"].ToString()!,
                        },
                        Job = new EmployeeJob
                        {
                            Title = reader["JobTitle"].ToString()!,
                            Salary = reader["Salary"] is DBNull ? 0 : Convert.ToDecimal(reader["Salary"]),
                            Department = new Department
                            {
                                Id = Convert.ToInt32(reader["DepartmentId"]),
                                Name = reader["DepartmentName"].ToString()!,
                            }
                        }
                    };
                    employees.Add(employee);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving employees.", ex);
            }
            return employees;
        }

        public async Task<decimal> GetTotalSalaryForAllEmployees()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("GetTotalEmployeeSalaries", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            return result == DBNull.Value ? 0m : Convert.ToDecimal(result);
        }
        public async Task DeleteAsync(int employeeId)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while deleting the employee.", ex);
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("GetEmployeesWithJobsByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString()!,
                        Address = reader["Address"] is DBNull ? string.Empty : reader["Address"].ToString(),
                        Gender = new Gender
                        {
                            Id = Convert.ToInt32(reader["GenderId"]),
                            Name = reader["GenderName"].ToString()!,
                        },
                        Job = new EmployeeJob
                        {
                            Title = reader["JobTitle"].ToString()!,
                            Salary = reader["Salary"] is DBNull ? 0 : Convert.ToDecimal(reader["Salary"]),
                            Department = new Department
                            {
                                Id = Convert.ToInt32(reader["DepartmentId"]),
                                Name = reader["DepartmentName"].ToString()!,
                            }
                        }
                    };
                    return employee;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while getting the employee with id", ex);
            }
            return null;
        }

        public async Task UpdateAsync(Employee employee)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("UpdateEmployeeWithJob", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeId", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@GenderId", employee.Gender.Id);
                command.Parameters.AddWithValue("@DepartmentId", employee.Job.Department.Id);
                command.Parameters.AddWithValue("@JobTitle", employee.Job.Title);
                command.Parameters.AddWithValue("@Salary", employee.Job.Salary);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while updating the employee.", ex);
            }
        }
    }
}
