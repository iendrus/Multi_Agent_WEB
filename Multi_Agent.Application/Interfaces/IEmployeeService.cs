using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Employee;
using Multi_Agent.Application.ViewModels.InsuranceCompany;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Interfaces
{
    public interface IEmployeeService
    {
        //int AddEmployee(NewEmployeeVm employee);

        EmployeeForListVm GetEmployeeDetails(int employeeId);

        ListEmployeeForListVM GetAllEmployeesCustomersForList();

        List<EmployeeForListVm> GetActiveAgentsList();

    }
}
