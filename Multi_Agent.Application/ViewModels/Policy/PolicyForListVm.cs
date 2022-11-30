using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class PolicyForListVm : IMapFrom<Multi_Agent.Domain.Model.Policy>
    {
        public int Id { get; set; } 
        public string PolicyNumber { get; set; }

        public string PolicyStatusName { get; set; }
        public string PolicyTypeName { get; set; }

        public string CustomerFullName { get; set; }
        
        public string InsuranceCompanyName { get; set; }
        // ...?
        public DateTime PolicyDateStart { get; set; }
        public DateTime PolicyDateEnd { get; set; }
        public DateTime PolicyDate { get; set; }


        public string PaymentTypeName { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.Policy, PolicyForListVm>()
                .ForMember(s => s.CustomerFullName, opt => opt.MapFrom(d => d.Customer.Surname  + " " 
                    + d.Customer.Name + " " 
                    + d.Customer.CompanyName ));
        }

    }
}
