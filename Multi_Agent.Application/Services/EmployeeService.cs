using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Employee;
using Multi_Agent.Application.ViewModels.Policy;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _eployeeRepo;
        private readonly IMapper _mapper;


        public EmployeeService(IEmployeeRepository eployeeRepo, IMapper mapper)
        {
            _eployeeRepo = eployeeRepo;
            _mapper = mapper;
        }

        public ListEmployeeForListVM GetAllEmployeesForList()
        {
            var employees = _eployeeRepo.GetAllActiveEmployee()
                .ProjectTo<EmployeeForListVm>(_mapper.ConfigurationProvider).ToList();
            var employeeList = new ListEmployeeForListVM()
            {
                Employees = employees,
                Count = employees.Count
            };
            return employeeList;
        }

        public List<EmployeeForListVm> GetActiveAgentsList()
        {
            var list = (from e in _eployeeRepo.GetAllActiveEmployee()

                            join ur in _eployeeRepo.GetAllEmployeUserRole() on e.Id equals ur.EmployeeId
                            join r in _eployeeRepo.GetAllUserRole() on ur.UserRoleId equals r.Id
                            where r.Id == "AG"
                        select new EmployeeForListVm()
                        {
                            Id = e.Id,
                            FullName = e.Name + " " + e.Surname,
                            EmailAddress = e.EmailAddress,
                            Position = e.Position
                        })
                        
                   .ProjectTo<EmployeeForListVm>(_mapper.ConfigurationProvider).ToList();
            return list;
        }


        public EmployeeForListVm GetEmployeeDetails(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
