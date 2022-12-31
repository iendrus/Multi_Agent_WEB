using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Interfaces;
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
            return _context.InsuranceCompanies.Where(p => p.IsActive == true);
        }

        public void AddInsuranceCompany(InsuranceCompany insuranceCompany)
        {
            _context.InsuranceCompanies.Add(insuranceCompany);
            _context.SaveChanges();
        }


        public InsuranceCompany GetInsuranceCompany(string id)
        {
            var item = _context.InsuranceCompanies
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.ModifiedByNavigation)
                .FirstOrDefault(x => x.Id == id);
            return item;
        }

        public void UpdateInsuranceCompany(InsuranceCompany item)
        {
            if (item != null)
            {
                _context.Update(item);
                _context.SaveChanges();
            }
        }

        public void DeleteInsuranceCompany(string id)
        {
            var item = _context.InsuranceCompanies.Find(id);
            if (item != null)
            {
                item.IsActive = false;
                _context.Update(item);
                _context.SaveChanges();
            }
        }
    }
}
