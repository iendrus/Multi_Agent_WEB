using AutoMapper;
using AutoMapper.QueryableExtensions;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Application.ViewModels.Policy;
using Multi_Agent.Domain.Interfaces;
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



        public CustomerForListVm GetCustomerDetails(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
