using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class PolicyContinuation
{
    public int PolicyPreviousId { get; set; }

    public int PolicyContinuedId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Policy PolicyContinued { get; set; } = null!;

    public virtual Policy PolicyPrevious { get; set; } = null!;
}
