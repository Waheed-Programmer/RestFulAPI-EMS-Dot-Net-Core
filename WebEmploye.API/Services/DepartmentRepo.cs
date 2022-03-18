using Microsoft.EntityFrameworkCore;
using WebEmp_DLL.Data;
using WebEmp_DLL.Entities;
using WebEmploye.API.Infrastructure;

namespace WebEmploye.API.Services
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartment(Department Department)
        {
            var result = await _context.departments.AddAsync(Department);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department> DeleteDepartment(int id)
        {

            var result = await _context.departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if (result != null)
            {
               _context.departments.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.departments.Include(a=>a.EmployeeDepartment).ThenInclude(m=>m.Department)
                .FirstOrDefaultAsync(x=>x.DepartmentId == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.departments.ToListAsync();
        }

        public async Task<IEnumerable<Department>> Search(string name)
        {
            IQueryable<Department> query = _context.departments;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.DepartmentName.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var result = await _context.departments.FirstOrDefaultAsync(x=>x.DepartmentId==department.DepartmentId);
            if (result != null)
            {
                //result.DepartmentName = department.DepartmentName;
                //result.DateBirth = department.DateBirth;
                //result.Gender = department.Gender;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        } 
    }
}
