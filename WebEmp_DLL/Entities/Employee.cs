using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEmp_DLL.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateBirth  { get; set; }
    }

    public enum Gender 
    { 
    Male, Female, Other    
    }

}
