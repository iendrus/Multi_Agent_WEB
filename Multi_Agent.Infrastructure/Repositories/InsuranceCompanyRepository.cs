﻿using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Infrastructure.Repositories
{
    public class InsuranceCompanyRepository : IInsuranceCompanyRepository
    {
        private readonly Context _context;
        public InsuranceCompanyRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<InsuranceCompany> GetAllActiveInsuranceCompany()
        {
            return _context.InsuranceCompanies;
        }

        public int AddInsuranceCompany(InsuranceCompany insuranceCompany)
        {
            throw new NotImplementedException();
        }


        public InsuranceCompany GetInsuranceCompany(int Id)
        {
            throw new NotImplementedException();
        }
    }
}