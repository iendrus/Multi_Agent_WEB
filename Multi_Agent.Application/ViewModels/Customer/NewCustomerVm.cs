using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Routing.Constraints;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<Multi_Agent.Domain.Model.Customer>
    {
        public int Id { get; set; }

        [DisplayName("Nazwisko")]
        public string? Surname { get; set; }
        
        [DisplayName("Imię")]
        public string? Name { get; set; }

        [DisplayName("Nazwa firmy")]
        public string? CompanyName { get; set; }
        
        [DisplayName("Konsument")]
        public bool? IsHousehold { get; set; }
        
        [DisplayName("Adres email")]
        public string? EmailAddress { get; set; }
        
        [DisplayName("Numer telefonu")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; } = null!;

        [DisplayName("Kod pocztowy")]
        public string PostCode { get; set; } = null!;

        [DisplayName("Poczta")]
        public string PostOffice { get; set; } = null!;

        public string? Pesel { get; set; }

        public string? Nip { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        public NewCustomerVm()
        {
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, Multi_Agent.Domain.Model.Customer>().ReverseMap();
                
        }
    }


}

