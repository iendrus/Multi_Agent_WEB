using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Multi_Agent.Application.Helpers;
using Multi_Agent.Domain.Base;
using Multi_Agent.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Infrastructure
{
    public partial class Context : IdentityDbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeUserRole> EmployeeUserRoles { get; set; }

        public virtual DbSet<Installment> Installments { get; set; }

        public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

        public virtual DbSet<PaymentType> PaymentTypes { get; set; }

        public virtual DbSet<Policy> Policies { get; set; }

        public virtual DbSet<PolicyContinuation> PolicyContinuations { get; set; }

        public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; }

        public virtual DbSet<PolicyType> PolicyTypes { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<VPolicy> VPolicies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JFQEPNF\\SQLEXPRESS;Initial Catalog=MultiAgent;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -------------- poniższą linie dodano w celu wyelinowania błedu:
            //System.InvalidOperationException: 'The entity type 'IdentityUserLogin<string>' requires a primary key to be defined.
            // If you intended to use a keyless entity type,
            // call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07BCCF7A1E");

                entity.ToTable("Customer");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.HasIndex(e => e.Nip, "idx_NIP");

                entity.HasIndex(e => e.Pesel, "idx_PESEL");

                entity.HasIndex(e => e.Surname, "idx_Surname");

                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.CompanyName).HasMaxLength(255);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.EmailAddress).HasMaxLength(255);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsHousehold)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(60);
                entity.Property(e => e.Nip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NIP");
                entity.Property(e => e.Pesel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PESEL");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.PostOffice).HasMaxLength(60);
                entity.Property(e => e.Surname).HasMaxLength(60);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CustomerCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CustomerModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Customer_ModifiedBy");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07626C472B");

                entity.ToTable("Employee");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.DismissalDate).HasColumnType("datetime");
                entity.Property(e => e.EmailAddress).HasMaxLength(255);
                entity.Property(e => e.EmploymentDate).HasColumnType("datetime");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.Login).HasMaxLength(30);
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(60);
                entity.Property(e => e.Position).HasMaxLength(60);
                entity.Property(e => e.Surname).HasMaxLength(60);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InverseModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Employee_ModifiedBy");
            });

            modelBuilder.Entity<EmployeeUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserRoleId, e.EmployeeId }).HasName("PK__Employee__3A3A8EC444A34770");

                entity.ToTable("EmployeeUserRole");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.UserRoleId)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EmployeeUserRoleCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeUserRole_CreatedBy");

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeUserRoleEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeId");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.EmployeeUserRoleModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_EmployeeUserRole_ModifiedBy");

                entity.HasOne(d => d.UserRole).WithMany(p => p.EmployeeUserRoles)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleId");
            });

            modelBuilder.Entity<Installment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Installm__3214EC075796895C");

                entity.ToTable("Installment");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.Amount).HasColumnType("money");
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InstallmentCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Installment_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InstallmentModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Installment_ModifiedBy");

                entity.HasOne(d => d.Policy).WithMany(p => p.Installments)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Installme__Polic__75A278F5");
            });

            modelBuilder.Entity<InsuranceCompany>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC07989691B9");

                entity.ToTable("InsuranceCompany");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.NIP).HasMaxLength(15);
                entity.Property(e => e.EmailAddress).HasMaxLength(255);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.ContactPerson).HasMaxLength(120);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InsuranceCompanyCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsuranceCompany_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InsuranceCompanyModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_InsuranceCompany_ModifiedBy");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__PaymentT__3214EC0776202793");

                entity.ToTable("PaymentType");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(60);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PaymentTypeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentType_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PaymentTypeModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PaymentType_ModifiedBy");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Policy__3214EC076CA91DEA");

                entity.ToTable("Policy");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.InsuranceCompanyId)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsForeign).HasDefaultValueSql("((0))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.PaymentTypeId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('PRZ')");
                entity.Property(e => e.PolicyDate).HasColumnType("date");
                entity.Property(e => e.PolicyDateEnd).HasColumnType("date");
                entity.Property(e => e.PolicyDateStart).HasColumnType("date");
                entity.Property(e => e.PolicyNumber).HasMaxLength(30);
                entity.Property(e => e.PolicyStatusId)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.PolicyTypeId)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.Premium).HasColumnType("money");
                entity.Property(e => e.PremiumPaid).HasColumnType("money");
                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agent).WithMany(p => p.PolicyAgents)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__AgentId__619B8048");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PolicyCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policy_CreatedBy");

                entity.HasOne(d => d.Customer).WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__Customer__5AEE82B9");

                entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.Policies)
                    .HasForeignKey(d => d.InsuranceCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__Insuranc__5BE2A6F2");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PolicyModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Policy_ModifiedBy");

                entity.HasOne(d => d.PaymentType).WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__PaymentT__5EBF139D");

                entity.HasOne(d => d.PolicyStatus).WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PolicyStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__PolicySt__5DCAEF64");

                entity.HasOne(d => d.PolicyType).WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PolicyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Policy__PolicyTy__5CD6CB2B");
            });

            modelBuilder.Entity<PolicyContinuation>(entity =>
            {
                entity.HasKey(e => new { e.PolicyPreviousId, e.PolicyContinuedId }).HasName("PK__PolicyCo__2C089192000969DE");

                entity.ToTable("PolicyContinuation");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PolicyContinuationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyContinuation_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PolicyContinuationModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PolicyContinuation_ModifiedBy");

                entity.HasOne(d => d.PolicyContinued).WithMany(p => p.PolicyContinuationPolicyContinueds)
                    .HasForeignKey(d => d.PolicyContinuedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PolicyCon__Polic__6E01572D");

                entity.HasOne(d => d.PolicyPrevious).WithMany(p => p.PolicyContinuationPolicyPrevious)
                    .HasForeignKey(d => d.PolicyPreviousId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PolicyCon__Polic__6D0D32F4");
            });

            modelBuilder.Entity<PolicyStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__PolicySt__3214EC07C9A23A8D");

                entity.ToTable("PolicyStatus");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(60);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PolicyStatusCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyStatus_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PolicyStatusModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PolicyStatus_ModifiedBy");
            });

            modelBuilder.Entity<PolicyType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__PolicyTy__3214EC079B4B9E3E");

                entity.ToTable("PolicyType");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PolicyTypeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyType_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PolicyTypeModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PolicyType_ModifiedBy");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC074EDC34F2");

                entity.ToTable("UserRole");

                entity.HasIndex(e => e.IsActive, "idx_IsActive");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)

                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
                entity.Property(e => e.RoleName).HasMaxLength(60);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserRoleCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.UserRoleModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserRole_ModifiedBy");
            });

            modelBuilder.Entity<VPolicy>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("V_Policy");

                entity.Property(e => e.AgentName).HasMaxLength(121);
                entity.Property(e => e.CustomerFullName).HasMaxLength(377);
                entity.Property(e => e.InsuranceCompanyName).HasMaxLength(255);
                entity.Property(e => e.PolicyDate).HasColumnType("date");
                entity.Property(e => e.PolicyDateEnd).HasColumnType("date");
                entity.Property(e => e.PolicyDateStart).HasColumnType("date");
                entity.Property(e => e.PolicyNumber).HasMaxLength(30);
                entity.Property(e => e.PolisyStatusName).HasMaxLength(60);
                entity.Property(e => e.PolisyTypeName).HasMaxLength(100);
                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).CreatedBy = HelperFunctions.GetCurrentUserId();
                    ((BaseEntity)entityEntry.Entity).IsActive = true;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).ModifiedAt = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).ModifiedBy = HelperFunctions.GetCurrentUserId();
                }
            }

            return base.SaveChanges();
        }
    }

}
