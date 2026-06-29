using CRUD.Data;
using CRUD.Model;
using CRUD.Model.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public EmployeeController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            List <EmployeDTOOutput> employeeList = [];
            var employees = dbContext.Employees.ToList();
            employees.ForEach(employee => employeeList.Add(
                new EmployeDTOOutput
                {
                    id = employee.Id,
                    name = employee.Name,
                    email = employee.Email,
                    role = employee.Role
                }
                ));

            return Ok(employeeList);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeDTOInput input)
        {
            Employee employee = new Employee();
            employee.Name = input.name;
            employee.Email = input.email;
            employee.Role = input.role;
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
           

            return Ok(employee);

        }
        [HttpPut]
        public IActionResult UpdateEmployee(int id, EmployeDTOInput updatedData) {
            var employee = dbContext.Employees.Find(id);
            if(employee==null)
            {
                return Ok("Employee not found");
            }
            employee.Name = updatedData.name;
            employee.Email = updatedData.email;
            employee.Role = updatedData.role;

            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id) {

            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return Ok("Employee not found");
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok( new { status = "success",
                isDeleted = true
            });

        }
    }
}
