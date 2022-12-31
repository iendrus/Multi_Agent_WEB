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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PolicyDate { get; set; }

        [DisplayName("Początek polisy")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PolicyDateStart { get; set; }

        [DisplayName("Koniec polisy")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PolicyDateEnd { get; set; }

        [DisplayName("Przypis")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}", ApplyFormatInEditMode = true)]
        public decimal Premium { get; set; }

        [DisplayName("Inkaso")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}", ApplyFormatInEditMode = true)]
        public decimal PremiumPaid { get; set; }

        [DisplayName("Polisa obca")]
        public bool? IsForeign { get; set; }

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
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPolicyVm, Multi_Agent.Domain.Model.Policy>().ReverseMap();
        }
    }
}
