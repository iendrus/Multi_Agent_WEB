﻿using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class PolicyStatus : BaseEntity
{
    public string Id { get; set; } 

    public string Name { get; set; } = null!;


    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual ICollection<Policy> Policies { get; } = new List<Policy>();
}
