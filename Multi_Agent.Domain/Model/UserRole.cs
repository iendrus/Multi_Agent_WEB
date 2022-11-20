using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class UserRole
{
    public string Id { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<EmployeeUserRole> EmployeeUserRoles { get; } = new List<EmployeeUserRole>();

    public virtual Employee? ModifiedByNavigation { get; set; }
}
