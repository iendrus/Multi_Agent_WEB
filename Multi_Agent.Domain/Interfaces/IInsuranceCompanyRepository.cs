using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Domain.Interfaces
{
    public interface IInsuranceCompanyRepository
    {
        IQueryable<InsuranceCompany> GetAllActiveInsuranceCompany();
        InsuranceCompany GetInsuranceCompany(string id);


        //void DeleteCustomer(int Id);
        void AddInsuranceCompany(InsuranceCompany insuranceCompany);
        void UpdateInsuranceCompany(InsuranceCompany item);
        void DeleteInsuranceCompany(string id);
    }
}
