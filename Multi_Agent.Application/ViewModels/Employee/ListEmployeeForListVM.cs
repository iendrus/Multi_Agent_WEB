using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Employee
{
    public class ListEmployeeForListVM : IMapFrom<Multi_Agent.Domain.Model.Employee>
    {
        public List<EmployeeForListVm> Employees { get; set; }
        public int Count { get; set; }
    }
}
