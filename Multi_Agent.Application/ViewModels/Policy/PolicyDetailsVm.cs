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
    internal class PolicyDetailsVm : IMapFrom<Multi_Agent.Domain.Model.Policy>
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }

        public string PolicyTypeName { get; set; }

        public string PolicyStatusName { get; set; }

        public string CustomerFullName { get; set; }

        public DateTime PolicyDate { get; set; }

        public DateTime PolicyDateStart { get; set; }

        public DateTime PolicyDateEnd { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.Policy, PolicyDetailsVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(s => s.CustomerFullName, opt => opt.MapFrom(d => d.Customer.Surname + " " + d.Customer.Name))
                .ForMember(s => s.PolicyStatusName, opt => opt.MapFrom(d => d.PolicyStatus.Name))
                .ForMember(s => s.PolicyTypeName, opt => opt.MapFrom(d => d.PolicyType.Name));
        }

    }
}
