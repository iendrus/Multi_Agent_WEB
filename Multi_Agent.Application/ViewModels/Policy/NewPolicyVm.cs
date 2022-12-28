using AutoMapper;
using Multi_Agent.Application.Mapping;
using Multi_Agent.Application.Services;
using Multi_Agent.Application.ViewModels.Customer;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Multi_Agent.Application.ViewModels.Policy
{
    public class NewPolicyVm:IMapFrom<Multi_Agent.Domain.Model.Policy>
    {

        public int Id { get; set; }

        [DisplayName("Numer polisy")]
        public string PolicyNumber { get; set; } = null!;

        [DisplayName("Numer rejestracyjny")]
        public string? RegistrationNumber { get; set; }

        [DisplayName("Data polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDate { get; set; }

        [DisplayName("Początek polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDateStart { get; set; }

        [DisplayName("Koniec polisy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PolicyDateEnd { get; set; }

        [DisplayName("Przypis")]
        public decimal Premium { get; set; }

        [DisplayName("Inkaso")]
        public decimal PremiumPaid { get; set; }

        [DisplayName("Data utworzenia")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Polisa obca")]
        public bool? IsForeign { get; set; }

        [DisplayName("Utwrozył")]
        public int CreatedBy { get; set; }

        public bool? IsActive { get; set; } //= true;
        [DisplayName("Klient")]
        public int CustomerId { get; set; }

        [DisplayName("Towarzystwo")]
        public string InsuranceCompanyId { get; set; }

        [DisplayName("Rodzaj płatności")]
        public string PaymentTypeId { get; set; }
        [DisplayName("Typ polisy")]
        public string PolicyTypeId { get; set; }
        [DisplayName("Status polisy")]
        public string PolicyStatusId { get; set; }
        [DisplayName("Agent")]
        public int AgentId { get; set; }


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
