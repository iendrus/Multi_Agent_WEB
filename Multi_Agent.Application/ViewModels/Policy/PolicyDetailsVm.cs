using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class PolicyDetailsVm : IMapFrom<Multi_Agent.Domain.Model.Policy>
    {
        public int Id { get; set; }

        [DisplayName("Numer polisy")]
        public string PolicyNumber { get; set; } = null!;

        [DisplayName("Numer rejestracyjny")]
        public string? RegistrationNumber { get; set; }

        [DisplayName("Data polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDate { get; set; }

        [DisplayName("Początek polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDateStart { get; set; }
        
        [DisplayName("Koniec polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDateEnd { get; set; }

        [DisplayName("Przypis")]
        public decimal Premium { get; set; }

        [DisplayName("Inkaso")]
        public decimal PremiumPaid { get; set; }

        [DisplayName("Data utworzenia")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Polisa obca")]
        public bool? IsForeign { get; set; }
        
        [DisplayName("Utwrozył")]
        public string CreatedBy { get; set; }

        [DisplayName("Data modyfikacji")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ModifiedAt { get; set; }
        
        [DisplayName("Zmodyfikował")]
        public string ModifiedBy { get; set; }

        [DisplayName("Rodzaj polisy")]
        public string PolicyTypeName { get; set; }

        [DisplayName("Status polisy")]
        public string PolicyStatusName { get; set; }

        [DisplayName("Nazwa Klienta")]
        public string CustomerFullName { get; set; } = null!;
        
        [DisplayName("Agent")]
        public string AgentFullName { get; set; }
        [DisplayName("Towarzystwo Ubezpieczeniowe")]
        public string InsuranceCompanyName { get; set; }

        [DisplayName("Rodzaj płatności")]
        public string PaymentTypeName { get; set; }



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
