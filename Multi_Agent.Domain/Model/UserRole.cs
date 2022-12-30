using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class UserRole : BaseEntity
{
    public string Id { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<EmployeeUserRole> EmployeeUserRoles { get; } = new List<EmployeeUserRole>();

    public virtual Employee? ModifiedByNavigation { get; set; }
}
