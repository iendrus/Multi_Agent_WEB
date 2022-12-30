using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                customer.IsActive = false;
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }

        public int AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer.Id;
            }
            return 0;
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = _context.Customers
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.ModifiedByNavigation)
                .FirstOrDefault(p => p.Id == customerId);
            return customer;
        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _context.Customers.Where(p => p.IsActive == true);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                _context.Update(customer);
                _context.SaveChanges();
            }
        }

    }
}
