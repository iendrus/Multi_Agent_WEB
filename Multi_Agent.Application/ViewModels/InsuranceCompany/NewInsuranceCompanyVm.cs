using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.InsuranceCompany
{
    public class NewInsuranceCompanyVm : IMapFrom<Multi_Agent.Domain.Model.InsuranceCompany>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsActive { get; set; }


        public NewInsuranceCompanyVm()
        {
            if (CreatedBy == 0)
            {
                CreatedAt = DateTime.Now;
                CreatedBy = CommonService.GetCurrentUser();
                IsActive = true;
            }
            else
            {
                ModifiedAt = DateTime.Now;
                ModifiedBy = CommonService.GetCurrentUser();
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewInsuranceCompanyVm, Multi_Agent.Domain.Model.InsuranceCompany>();

        }
    }
}
