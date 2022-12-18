using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.InsuranceCompany
{
    public class ListInsuranceCompanyForListVm : IMapFrom<Multi_Agent.Domain.Model.InsuranceCompany>
    {
        public List<InsuranceCompanyVm> InsuranceCompanies { get; set; }
        public int Count { get; set; }
    }
}
