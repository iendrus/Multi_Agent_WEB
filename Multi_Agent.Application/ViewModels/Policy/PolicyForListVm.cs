using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class PolicyForListVm : IMapFrom<Multi_Agent.Domain.Model.Policy>
    {
        public int Id { get; set; }
        
        [DisplayName("Numer polisy")]
        public string PolicyNumber { get; set; }

        [DisplayName("Status polisy")]
        public string PolicyStatusName { get; set; }

        [DisplayName("Rodzaj polisy")]
        public string PolicyTypeName { get; set; }

        [DisplayName("Nazwa Klienta")]
        public string CustomerFullName { get; set; }

        [DisplayName("Towarzystwo Ubezpieczeniowe")]
        public string InsuranceCompanyName { get; set; }
        
        [DisplayName("Początek polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDateStart { get; set; }

        [DisplayName("Koniec polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDateEnd { get; set; }

        [DisplayName("Data polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDate { get; set; }

        [DisplayName("Przypis")]
        public decimal Premium { get; set; }

        [DisplayName("Inkaso")]
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
