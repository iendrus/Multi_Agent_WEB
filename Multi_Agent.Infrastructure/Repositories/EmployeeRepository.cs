using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {


        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public int AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetAllActiveEmployee()
        {
            return _context.Employees;
        }

        public IQueryable<EmployeeUserRole> GetAllEmployeUserRole()
        {
            return _context.EmployeeUserRoles;
        }

        public IQueryable<UserRole> GetAllUserRole()
        {
            return _context.UserRoles;
        }

        public Employee GetEmployee(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
