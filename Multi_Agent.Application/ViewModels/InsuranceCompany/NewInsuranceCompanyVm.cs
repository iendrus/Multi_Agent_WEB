using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.InsuranceCompany
{
    public class NewInsuranceCompanyVm : IMapFrom<Multi_Agent.Domain.Model.InsuranceCompany>
    {
        [DisplayName("Kod")]
        public string Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("NIP")]
        public string? NIP { get; set; }
        
        [DisplayName("Adres email")]
        public string? EmailAddress { get; set; }
        
        [DisplayName("Numer telefonu")]
        public string? PhoneNumber { get; set; }
        
        [DisplayName("Osoba do kontaktu")]
        public string? ContactPerson { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewInsuranceCompanyVm, Multi_Agent.Domain.Model.InsuranceCompany>().ReverseMap();

        }
    }
}
