using AutoMapper.Configuration.Conventions;
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
        CustomerDetailsVm GetCustomerDetails(int Id);
        int AddCustomer(NewCustomerVm customer);
        NewCustomerVm GetCustomerForEdit(int id);

        void UpdateCustomer(NewCustomerVm model);

        void DeleteCustomer(int id);


    }
}
