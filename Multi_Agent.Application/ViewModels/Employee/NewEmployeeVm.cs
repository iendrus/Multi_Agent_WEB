using AutoMapper;
using Multi_Agent.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Multi_Agent.Application.ViewModels.Employee
{
    public class NewEmployeeVm : IMapFrom<Multi_Agent.Domain.Model.Employee>
    {

        public int Id { get; set; }
        [DisplayName("Imię")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

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

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewEmployeeVm, Multi_Agent.Domain.Model.Employee>().ReverseMap();

        }

    }
}
