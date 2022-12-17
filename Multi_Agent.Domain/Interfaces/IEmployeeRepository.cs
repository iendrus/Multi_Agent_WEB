using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Domain.Interfaces
{
    public interface IEmployeeRepository
    {

        IQueryable<Employee> GetAllActiveEmployee();
        IQueryable<UserRole> GetAllUserRole();
        IQueryable<EmployeeUserRole> GetAllEmployeUserRole();
        Employee GetEmployee(int Id);

        int AddEmployee(Employee employee);
    }
}
