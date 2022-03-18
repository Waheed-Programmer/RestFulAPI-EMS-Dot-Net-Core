using Microsoft.EntityFrameworkCore;
using WebEmp_DLL.Data;
using WebEmp_DLL.Entities;
using WebEmploye.API.Infrastructure;

namespace WebEmploye.API.Services
{
    public class EmployeRepo : IEmployeRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {

            var result = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (result != null)
            {
               _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(a=>a.EmployeeDepartment).ThenInclude(m=>m.Department)
                .FirstOrDefaultAsync(x=>x.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name)
        {
            IQueryable<Employee> query = _context.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.EmployeeName.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x=>x.EmployeeId==employee.EmployeeId);
            if (result != null)
            {
                result.EmployeeName = employee.EmployeeName;
                result.DateBirth = employee.DateBirth;
                result.Gender = employee.Gender;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        } 
    }
}
