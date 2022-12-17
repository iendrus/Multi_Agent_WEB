using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class NewPolicyVm:IMapFrom<Multi_Agent.Domain.Model.Policy>
    {
        public int Id { get; set; }



        public string PolicyNumber { get; set; } = null!;

        public string? RegistrationNumber { get; set; }

        public DateTime PolicyDate { get; set; }

        public DateTime PolicyDateStart { get; set; }

        public DateTime PolicyDateEnd { get; set; }

        public decimal Premium { get; set; }

        public decimal PremiumPaid { get; set; }


        public bool? IsForeign { get; set; } 



        public DateTime CreatedAt { get; set; } 

        public bool? IsActive { get; set; } = true;



        /// <summary>
        /// 
        /// </summary>
        /// 
        public int CustomerId { get; set; }
        public string InsuranceCompanyId { get; set; } = null!;

        public string PaymentTypeId { get; set; } = null!;

        public string PolicyTypeId { get; set; } = null!;

        public string PolicyStatusId { get; set; } = null!;

        public int AgentId { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }



        public ICollection<PolicyStatus> PolicyStatuses { get; set; }

        public IEnumerable<CustomerForListVm>  customers { get; set; }


        public NewPolicyVm()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = CommonService.GetCurrentUser();
            IsActive = true;
            IsForeign = false;
            PolicyDateStart = DateTime.Today;
            PolicyDate = DateTime.Today;
            PolicyDateEnd = DateTime.Today;
            Premium = 0;
            PremiumPaid = 0;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPolicyVm, Multi_Agent.Domain.Model.Policy>();


        }



    }
}
