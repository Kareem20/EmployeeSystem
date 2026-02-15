using EmployeeManagement.API.Core.Entities;
using EmployeeManagement.API.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace EmployeeManagement.API.Infrastructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly string _connectionString;
        public GenderRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }
        public async Task<IReadOnlyList<Gender>> GetAllAsync()
        {
            var genders = new List<Gender>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT GenderId, GenderName FROM Genders", connection);
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var gender = new Gender
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                genders.Add(gender);
            }
            return genders;
        }
    }
}
