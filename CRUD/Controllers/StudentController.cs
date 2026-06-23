using CRUD.Model;
using CRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices _studentServices;

        public StudentController(StudentServices studentService)
        {
            _studentServices = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudent() { 
        List<Model.StudentOutputDTO> students = _studentServices.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentInputDTO input) {
            _studentServices.AddStudent(input);
            return Ok("Student added successfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentInputDTO input) {
            _studentServices.UpdateStudent(input, id);
            return Ok("Student updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentServices.DeleteStudent(id);
            return Ok("Student deleted successfully");
        }

    }
}
