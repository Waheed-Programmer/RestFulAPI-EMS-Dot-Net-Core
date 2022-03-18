using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEmp_DLL.Entities;
using WebEmploye.API.Infrastructure;

namespace WebEmploye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeRepo _employeRepo;

        public EmployeeController(IEmployeRepo employeRepo)
        {
            _employeRepo = employeRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee()
        {
            try
            {
            return Ok(await _employeRepo.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<Employee>> GetEmployees(int id)
        {
            try
            {
                var result = await _employeRepo.GetById(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }
    
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployees(Employee employee)
        {
            try
            {
                //var result = await _employeRepo.GetById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                var create = await _employeRepo.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = create.EmployeeId }, create);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpPut("id:int")]
        public async Task<ActionResult<Employee>> UpdateEmployees(int id ,Employee employee)
        {
            try
            {
                if(id != employee.EmployeeId)
                {
                    return BadRequest("Id Mismatch");
                }
                var result = await _employeRepo.GetById(id);
                if (result == null)
                {
                    return NotFound($"Employe Id= {id} Not Found");
                }
                return await _employeRepo.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult<Employee>> deleteEmployees(int id)
        {
            try
            {
                
                var result = await _employeRepo.GetById(id);
                if (result == null)
                {
                    return NotFound($"Employe Id= {id} Not Found");
                }
                return await _employeRepo.DeleteEmployee(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult <IEnumerable<Employee>>> search(string name)
        {
            try
            {
               
                var result = await _employeRepo.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

    }
}
