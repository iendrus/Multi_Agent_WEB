using AutoMapper;
using Multi_Agent.Application.ViewModels.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.ViewModels.Customer
{
    public class ListCustomerForListVm
    {
        public List<CustomerForListVm> Customers { get; set; }
        public int Count { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Multi_Agent.Domain.Model.Customer, CustomerForListVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(c => c.Surname + " "
                    + c.Name + " "
                    + c.CompanyName))
                .ForMember(s => s.FullAddress, opt => opt.MapFrom(c => c.PostCode + " "
                    + c.PostOffice + ", "
                    + c.Address
                ));
        }
    }
}
