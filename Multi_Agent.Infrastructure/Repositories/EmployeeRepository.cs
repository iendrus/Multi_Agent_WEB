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
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }


        public IQueryable<Employee> GetAllActiveEmployee()
        {
            return _context.Employees.Where(p => p.IsActive == true);
        }

        public IQueryable<EmployeeUserRole> GetAllEmployeUserRole()
        {
            return _context.EmployeeUserRoles.Where(p => p.IsActive == true);
        }

        public IQueryable<UserRole> GetAllUserRole()
        {
            return _context.UserRoles.Where(p => p.IsActive == true);
        }

        public Employee GetEmployee(int Id)
        {
            var employee = _context.Employees
                .Include(x => x.CreatedByNavigation)
                .Include(x => x.ModifiedByNavigation)
                .FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                _context.Update(employee);
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                employee.IsActive = false;
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
        }
    }
}
