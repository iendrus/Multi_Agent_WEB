using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class PolicyDetailsVm : IMapFrom<Multi_Agent.Domain.Model.Policy>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string PolicyNumber { get; set; } = null!;

        public string? RegistrationNumber { get; set; }


        public DateTime PolicyDate { get; set; }

        public DateTime PolicyDateStart { get; set; }

        public DateTime PolicyDateEnd { get; set; }


        public decimal Premium { get; set; }

        public decimal PremiumPaid { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsForeign { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public string PolicyTypeName { get; set; }

        public string PolicyStatusName { get; set; }

        public string CustomerFullName { get; set; } = null!;
        public string AgentFullName { get; set; }

        public string InsuranceCompanyName { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.Policy, PolicyDetailsVm>()
                .ForMember(s => s.CustomerFullName, opt => opt.MapFrom(d => d.Customer.Surname + " "
                    + d.Customer.Name + " "
                    + d.Customer.CompanyName))
                .ForMember(s => s.AgentFullName, opt => opt.MapFrom(d => d.Agent.Surname + " " + d.Agent.Name))
                .ForMember(s => s.CreatedBy, opt => opt.MapFrom(d => d.CreatedByNavigation.Surname + " " + d.CreatedByNavigation.Name))
                .ForMember(s => s.ModifiedBy, opt => opt.MapFrom(d => d.ModifiedByNavigation.Surname + " " + d.ModifiedByNavigation.Name))
                ;

        }

    }
}
