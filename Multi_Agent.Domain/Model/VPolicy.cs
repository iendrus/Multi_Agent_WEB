using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class VPolicy
{
    public int PolicyId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public DateTime PolicyDate { get; set; }

    public DateTime PolicyDateStart { get; set; }

    public string? RegistrationNumber { get; set; }

    public DateTime PolicyDateEnd { get; set; }

    public string PolisyStatusName { get; set; } = null!;

    public string PolisyTypeName { get; set; } = null!;

    public string InsuranceCompanyName { get; set; } = null!;

    public int CustomerId { get; set; }

    public string AgentName { get; set; } = null!;

    public string? CustomerFullName { get; set; }
}
