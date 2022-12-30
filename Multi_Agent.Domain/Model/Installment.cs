using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class Installment : BaseEntity
{
    public int Id { get; set; }

    public int PolicyId { get; set; }

    public int InstallmentNumber { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public bool IsPaid { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Policy Policy { get; set; } = null!;
}
