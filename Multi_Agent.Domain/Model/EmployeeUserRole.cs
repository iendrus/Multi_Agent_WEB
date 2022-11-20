using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class EmployeeUserRole
{
    public string UserRoleId { get; set; } = null!;

    public int EmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
