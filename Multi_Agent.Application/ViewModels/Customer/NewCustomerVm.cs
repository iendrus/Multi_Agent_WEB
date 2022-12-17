using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<Multi_Agent.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string? Surname { get; set; }

        public string? Name { get; set; }

        public string? CompanyName { get; set; }

        public bool? IsHousehold { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string Address { get; set; } = null!;

        public string PostCode { get; set; } = null!;

        public string PostOffice { get; set; } = null!;

        public string? Pesel { get; set; }

        public string? Nip { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; } = 1;

        public bool IsActive { get; set; } 

        public NewCustomerVm()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = CommonService.GetCurrentUser();
            IsActive = true;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, Multi_Agent.Domain.Model.Customer>();
                
        }

    }




}
