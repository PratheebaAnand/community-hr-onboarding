using ClosedXML.Excel;
using OnboardEaseMini.Models;
using OnboardEaseMini.Repositories;

namespace OnboardEaseMini.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService(EmployeeRepository repo)
        {
            _repo = repo;
        }

        public void ImportExcel(Stream stream)
        {
            using var wb = new XLWorkbook(stream);

            var ws = wb.Worksheet(1);

            foreach (var row in ws.RowsUsed().Skip(1))
            {
                DateTime doj;
                var dojCell = row.Cell(3).GetValue<string>();

                DateTime.TryParse(dojCell, out doj);

                var emp = new Employee
                {
                    Name = row.Cell(1).GetString(),
                    Email = row.Cell(2).GetString(),
                    DOJ = doj,
                    Role = row.Cell(4).GetString()
                };
                int empId = _repo.Add(emp);
            }
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = _repo.GetAll();
            return employees;
        }
    }
}
