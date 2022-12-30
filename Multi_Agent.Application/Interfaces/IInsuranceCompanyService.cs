using Multi_Agent.Application.ViewModels.InsuranceCompany;
using Multi_Agent.Application.ViewModels.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Interfaces
{
    public interface IInsuranceCompanyService
    {

        void AddInsuranceCompany(NewInsuranceCompanyVm insuranceCompany);

        InsuranceCompanyVm GetInsuranceCompanyDetails(string id);

        public ListInsuranceCompanyForListVm GetAllInsuranceCompanyForList();
        object GetInsuranceCompanyForEdit(string id);
        void UpdateInsuranceCompany(NewInsuranceCompanyVm model);
        void DeleteInsuranceCompany(string id);
    }
}
