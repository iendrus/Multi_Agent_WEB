using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class Customer
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? CompanyName { get; set; }

    public bool? IsHousehold { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string Address { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string PostOffice { get; set; } = null!;

    public string? Pesel { get; set; }

    public string? Nip { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual ICollection<Policy> Policies { get; } = new List<Policy>();
}
