using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEmp_DLL.Entities;
using WebEmploye.API.Infrastructure;

namespace WebEmploye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentController( IDepartmentRepo departmentRepo)
        {            
            _departmentRepo = departmentRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee()
        {
            try
            {
            return Ok(await _departmentRepo.GetDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<Department>> GetDepartments(int id)
        {
            try
            {
                var result = await _departmentRepo.GetById(id);
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
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            try
            {
                //var result = await _employeRepo.GetById(id);
                if (department == null)
                {
                    return NotFound();
                }
                var create = await _departmentRepo.AddDepartment(department);
                return CreatedAtAction(nameof(GetDepartments), new { id = create.DepartmentId }, create);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpPut("id:int")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id ,Department department)
        {
            try
            {
                if(id != department.DepartmentId)
                {
                    return BadRequest("Id Mismatch");
                }
                var result = await _departmentRepo.GetById(id);
                if (result == null)
                {
                    return NotFound($"Employe Id= {id} Not Found");
                }
                return await _departmentRepo.UpdateDepartment(department);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult<Department>> deleteDepartment(int id)
        {
            try
            {
                
                var result = await _departmentRepo.GetById(id);
                if (result == null)
                {
                    return NotFound($"Employe Id= {id} Not Found");
                }
                return await _departmentRepo.DeleteDepartment(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data from Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult <IEnumerable<Department>>> search(string name)
        {
            try
            {
               
                var result = await _departmentRepo.Search(name);
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
