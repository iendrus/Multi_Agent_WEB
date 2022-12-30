using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class EmployeeUserRole : BaseEntity
{
    public string UserRoleId { get; set; } = null!;

    public int EmployeeId { get; set; }

    
    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
