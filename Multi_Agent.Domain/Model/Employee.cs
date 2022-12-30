using Multi_Agent.Domain.Base;
using System;
using System.Collections.Generic;

namespace Multi_Agent.Domain.Model;

public partial class Employee : BaseEntity
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Login { get; set; } = null!;

    public DateTime EmploymentDate { get; set; }

    public DateTime? DismissalDate { get; set; }


    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Customer> CustomerCreatedByNavigations { get; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerModifiedByNavigations { get; } = new List<Customer>();

    public virtual ICollection<EmployeeUserRole> EmployeeUserRoleCreatedByNavigations { get; } = new List<EmployeeUserRole>();

    public virtual ICollection<EmployeeUserRole> EmployeeUserRoleEmployees { get; } = new List<EmployeeUserRole>();

    public virtual ICollection<EmployeeUserRole> EmployeeUserRoleModifiedByNavigations { get; } = new List<EmployeeUserRole>();

    public virtual ICollection<Installment> InstallmentCreatedByNavigations { get; } = new List<Installment>();

    public virtual ICollection<Installment> InstallmentModifiedByNavigations { get; } = new List<Installment>();

    public virtual ICollection<InsuranceCompany> InsuranceCompanyCreatedByNavigations { get; } = new List<InsuranceCompany>();

    public virtual ICollection<InsuranceCompany> InsuranceCompanyModifiedByNavigations { get; } = new List<InsuranceCompany>();

    public virtual ICollection<Employee> InverseCreatedByNavigation { get; } = new List<Employee>();

    public virtual ICollection<Employee> InverseModifiedByNavigation { get; } = new List<Employee>();

    public virtual Employee? ModifiedByNavigation { get; set; }

    public virtual ICollection<PaymentType> PaymentTypeCreatedByNavigations { get; } = new List<PaymentType>();

    public virtual ICollection<PaymentType> PaymentTypeModifiedByNavigations { get; } = new List<PaymentType>();

    public virtual ICollection<Policy> PolicyAgents { get; } = new List<Policy>();

    public virtual ICollection<PolicyContinuation> PolicyContinuationCreatedByNavigations { get; } = new List<PolicyContinuation>();

    public virtual ICollection<PolicyContinuation> PolicyContinuationModifiedByNavigations { get; } = new List<PolicyContinuation>();

    public virtual ICollection<Policy> PolicyCreatedByNavigations { get; } = new List<Policy>();

    public virtual ICollection<Policy> PolicyModifiedByNavigations { get; } = new List<Policy>();

    public virtual ICollection<PolicyStatus> PolicyStatusCreatedByNavigations { get; } = new List<PolicyStatus>();

    public virtual ICollection<PolicyStatus> PolicyStatusModifiedByNavigations { get; } = new List<PolicyStatus>();

    public virtual ICollection<PolicyType> PolicyTypeCreatedByNavigations { get; } = new List<PolicyType>();

    public virtual ICollection<PolicyType> PolicyTypeModifiedByNavigations { get; } = new List<PolicyType>();

    public virtual ICollection<UserRole> UserRoleCreatedByNavigations { get; } = new List<UserRole>();

    public virtual ICollection<UserRole> UserRoleModifiedByNavigations { get; } = new List<UserRole>();
}
