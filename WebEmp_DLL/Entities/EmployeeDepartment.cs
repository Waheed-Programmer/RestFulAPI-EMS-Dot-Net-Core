using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEmp_DLL.Entities
{
    public class EmployeeDepartment
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
