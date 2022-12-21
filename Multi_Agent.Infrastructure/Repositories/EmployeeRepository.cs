using Microsoft.EntityFrameworkCore;
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
            initilalizeFields(employee, "add");
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }

        private Employee initilalizeFields(Employee employee, string operation)
        {
            var item = employee;
            switch (operation)
            {
                case "add":
                    item.CreatedAt = DateTime.Now;
                    item.CreatedBy = 1;
                    item.IsActive = true;
                    break;
                case "edit":
                    item.ModifiedAt = DateTime.Now;
                    item.ModifiedBy = 2;
                    break;
            }
            return item;
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
            var employee = _context.Employees
                .Include(x => x.CreatedByNavigation)
                .Include(x => x.ModifiedByNavigation)
                .FirstOrDefault(x => x.Id == Id);
            return employee;
        }
    }
}
