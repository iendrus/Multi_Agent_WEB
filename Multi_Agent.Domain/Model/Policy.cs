using Microsoft.EntityFrameworkCore;
using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class Policy : BaseEntity
{

    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public string? RegistrationNumber { get; set; }

    public string InsuranceCompanyId { get; set; } = null!;

    public string PolicyTypeId { get; set; } = null!;

    public string PolicyStatusId { get; set; } = null!;

    public DateTime PolicyDate { get; set; }

    public DateTime PolicyDateStart { get; set; }

    public DateTime PolicyDateEnd { get; set; }

    public string PaymentTypeId { get; set; } = null!;

    public decimal Premium { get; set; }

    public decimal PremiumPaid { get; set; }

    public int AgentId { get; set; }

    public bool? IsForeign { get; set; }

    public virtual Employee Agent { get; set; } = null!;

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Installment> Installments { get; } = new List<Installment>();

    public virtual InsuranceCompany InsuranceCompany { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual PaymentType PaymentType { get; set; } = null!;

    public virtual ICollection<PolicyContinuation> PolicyContinuationPolicyContinueds { get; } = new List<PolicyContinuation>();

    public virtual ICollection<PolicyContinuation> PolicyContinuationPolicyPrevious { get; } = new List<PolicyContinuation>();

    public virtual PolicyStatus PolicyStatus { get; set; } = null!;

    public virtual PolicyType PolicyType { get; set; } = null!;
}
