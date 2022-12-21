using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Employee
{
    public class EmployeeDetailsVm : IMapFrom<Multi_Agent.Domain.Model.Employee>

    {
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        [DisplayName("Pełna nazwa")]
        public string FullName { get; set; }

        [DisplayName("Stanowisko")]
        public string Position { get; set; }

        [DisplayName("Adres email")]
        public string EmailAddress { get; set; }

        [DisplayName("Login")]
        public string login { get; set; }

        [DisplayName("Data zatrudnienia")]
        public DateTime EmploymentDate { get; set; }

        [DisplayName("Data zwolnienia")]
        public DateTime? DismissalDate { get; set; }

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
            profile.CreateMap<Multi_Agent.Domain.Model.Employee, EmployeeDetailsVm>()
                 .ForMember(s => s.FullName, opt => opt.MapFrom(c => c.Surname + ' ' + c.Name))
               .ForMember(s => s.CreatedByFullName, opt => opt.MapFrom(c => c.CreatedByNavigation.Surname
                    + " " + c.CreatedByNavigation.Name))
               .ForMember(s => s.ModifiedByFullName, opt => opt.MapFrom(c => c.ModifiedByNavigation.Surname
                    + " " + c.ModifiedByNavigation.Name));
        }

    }
}
