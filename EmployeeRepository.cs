using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using OnboardEaseMini.Models;

namespace OnboardEaseMini.Repositories
{
    public class EmployeeRepository
    {
        //
        private readonly string _conn;

        public EmployeeRepository(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("DefaultConnection");
        }

        public int Add(Employee emp)
        {
            using var conn = new SqlConnection(_conn);

            return conn.ExecuteScalar<int>(
        @"INSERT INTO Employees(Name, Email, DOJ, Role)
          VALUES(@Name,@Email,@DOJ,@Role);
          SELECT CAST(SCOPE_IDENTITY() AS INT);",
        emp);
        }

        public List<Employee> GetAll()
        {
            using var conn = new SqlConnection(_conn);
            return conn.Query<Employee>("SELECT * FROM Employees").ToList();
        }
    }
}
