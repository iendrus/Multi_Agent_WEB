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

        public string InsuranceCompanyId { get; set; } = null!;


        public DateTime PolicyDate { get; set; }

        public DateTime PolicyDateStart { get; set; }

        public DateTime PolicyDateEnd { get; set; }


        public decimal Premium { get; set; }

        public decimal PremiumPaid { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsForeign { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

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
                    + d.Customer.CompanyName));

        }

    }
}
