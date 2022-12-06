using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomersForList();
        CustomerForListVm GetCustomerDetails(int Id);
        int AddCustomer(NewCustomerVm customer);


    }
}
