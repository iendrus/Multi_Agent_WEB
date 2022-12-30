using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class PolicyContinuation : BaseEntity
{
    public int PolicyPreviousId { get; set; }

    public int PolicyContinuedId { get; set; }


    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual Policy PolicyContinued { get; set; } = null!;

    public virtual Policy PolicyPrevious { get; set; } = null!;
}
