using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllActiveCustomers();
        Customer GetCustomer(int Id);
        void DeleteCustomer(int Id);
        int AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
