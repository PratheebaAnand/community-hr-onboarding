using Microsoft.AspNetCore.Mvc;
using OnboardEaseMini.Services;

namespace OnboardEaseMini.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Path.GetTempPath(), uniqueFileName);

            using var stream = file.OpenReadStream();

            _service.ImportExcel(stream);

            return Ok("Uploaded successfully!");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
         var employees=   _service.GetAll();
            return Ok(employees);
        }
    }
}
