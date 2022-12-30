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

        public string Id { get; set; }

        public string Name { get; set; }

        public string? NIP { get; set; }

        [DisplayName("Adres email")]
        public string? EmailAddress { get; set; }

        [DisplayName("Numer telefonu")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Osoba do kontaktu")]

        public string? ContactPerson { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.InsuranceCompany, InsuranceCompanyVm>();
        }

    }
}
