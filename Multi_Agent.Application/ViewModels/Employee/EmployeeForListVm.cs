﻿using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.ViewModels.InsuranceCompany;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Employee
{
    public class EmployeeForListVm : IMapFrom<Multi_Agent.Domain.Model.Employee>
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
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.Employee, EmployeeForListVm>()
                 .ForMember(s => s.FullName, opt => opt.MapFrom(c => c.Surname + ' ' + c.Name));
            profile.CreateMap<EmployeeForListVm, EmployeeForListVm>();
        }

    }
}
