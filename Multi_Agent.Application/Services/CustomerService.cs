using AutoMapper;
using AutoMapper.QueryableExtensions;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.ViewModels.Customer;
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

    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;

        }

        public int AddCustomer(NewCustomerVm customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            var id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public ListCustomerForListVm GetAllCustomersForList()
        {
            var customers = _customerRepo.GetAllActiveCustomers()
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            var customerList = new ListCustomerForListVm()
            {
                Customers = customers,
                Count = customers.Count
            };
            return customerList;
        }


        public CustomerDetailsVm GetCustomerDetails(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);
            return customerVm;
        }

        public NewCustomerVm GetCustomerForEdit(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVm = _mapper.Map<NewCustomerVm>(customer);
            return customerVm;
        }

        public void UpdateCustomer(NewCustomerVm model)
        {
            var customer = _mapper.Map<Customer>(model);
            if (customer != null)
            {
                _customerRepo.UpdateCustomer(customer);
            }
        }
    }
}
