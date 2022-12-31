using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.ViewModels.Policy;
using Multi_Agent.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.InsuranceCompany
{
    public class InsuranceCompanyVm : IMapFrom<Multi_Agent.Domain.Model.InsuranceCompany>
    {
        [DisplayName("Kod")]
        public string Id { get; set; }
        
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        public string? NIP { get; set; }

        [DisplayName("Adres email")]
        public string? EmailAddress { get; set; }

        [DisplayName("Numer telefonu")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Osoba do kontaktu")]

        public string? ContactPerson { get; set; }

        [DisplayName("Data utworzenia")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Data modyfikacji")]
        public DateTime? ModifiedAt { get; set; }

        [DisplayName("Utworzył")]
        public string CreatedByFullName { get; set; }

        [DisplayName("Zmodyfikował")]
        public string? ModifiedByFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.InsuranceCompany, InsuranceCompanyVm>()
                .ForMember(s => s.CreatedByFullName, opt => opt.MapFrom(d => d.CreatedByNavigation.Surname + " " + d.CreatedByNavigation.Name))
                .ForMember(s => s.ModifiedByFullName, opt => opt.MapFrom(d => d.ModifiedByNavigation.Surname + " " + d.ModifiedByNavigation.Name)); ;
        }

    }
}
