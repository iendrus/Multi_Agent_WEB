using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class InsuranceCompany : BaseEntity
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? NIP { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContactPerson { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual ICollection<Policy> Policies { get; } = new List<Policy>();
}
