using WebEmp_DLL.Entities;

namespace WebEmploye.API.Infrastructure
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> Search(string name);
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetById(int id);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
    }
}
