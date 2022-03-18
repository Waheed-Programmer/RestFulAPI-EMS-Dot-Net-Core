using WebEmp_DLL.Entities;
using WebEmploye.API.Infrastructure;

namespace WebEmploye.API.Services
{
    public class EmployeRepo : IEmployeRepo
    {
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
