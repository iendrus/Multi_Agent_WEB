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
        InsuranceCompany GetInsuranceCompany(int Id);


        //void DeleteCustomer(int Id);
        int AddInsuranceCompany(InsuranceCompany insuranceCompany);
    }
}
