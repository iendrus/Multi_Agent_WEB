using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Customer
{
    public  class CustomerDetailsVm : IMapFrom<Multi_Agent.Domain.Model.Customer>
    {
        public int Id { get; set; }

        [DisplayName ("Nazwa pełna")]
        public string? FullName { get; set; }

        [DisplayName("Adres")]
        public string? FullAddress { get; set; }
        
        [DisplayName("PESEL")]
        public string? Pesel { get; set; }
        
        [DisplayName("NIP")]
        public string? Nip { get; set; }

        [DisplayName("Adres email")]
        public string? EmailAddress { get; set; }

        [DisplayName("Numer telefonu")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Konsument")]
        public bool IsHousehold { get; set; }

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
            profile.CreateMap<Multi_Agent.Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(c => c.Surname + " "
                    + c.Name + " "
                    + c.CompanyName))
                .ForMember(s => s.FullAddress, opt => opt.MapFrom(c => c.PostCode + " "
                    + c.PostOffice + ", "
                    + c.Address
                ))
               .ForMember(s => s.CreatedByFullName, opt => opt.MapFrom(c => c.CreatedByNavigation.Surname
                    + " " + c.CreatedByNavigation.Name))
               .ForMember(s => s.ModifiedByFullName, opt => opt.MapFrom(c => c.ModifiedByNavigation.Surname
                    + " " + c.ModifiedByNavigation.Name));
        }


    }
}
