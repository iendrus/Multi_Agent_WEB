using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class PolicyStatus
{
    public string Id { get; set; } 

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual ICollection<Policy> Policies { get; } = new List<Policy>();
}
