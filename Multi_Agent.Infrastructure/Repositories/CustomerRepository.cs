﻿using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteCustomer(int Id)
        {
            var customer = _context.Customers.Find(Id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }


        public Customer GetCustomer(int customerId)
        {
            var customer = _context.Customers
                 .FirstOrDefault(p => p.Id == customerId);
            return customer;
        }


        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _context.Customers;
        }


    }
}
