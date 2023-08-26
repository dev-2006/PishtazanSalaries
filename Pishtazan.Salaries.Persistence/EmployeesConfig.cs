using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pishtazan.Salaries.Domain.Employees;

namespace Pishtazan.Salaries.Persistence
{
    internal class EmployeesConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> modelBuilder)
        {
            configureShadowPropertyForKey(modelBuilder);
            fixColumnNames(modelBuilder);
        }

        private static void configureShadowPropertyForKey(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder.Property<int>("EmployeeId");
            modelBuilder.HasKey("EmployeeId");
        }

        private static void fixColumnNames(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder.OwnsOne(x => x.FullName).OwnsOne(f => f.FirstName).Property(c => c.Value).
                            HasColumnName("FirstName").
                            IsRequired().
                            HasMaxLength(Name.MAX_LENGTH);

            modelBuilder.OwnsOne(x => x.FullName).OwnsOne(f => f.LastName).Property(c => c.Value).
                HasColumnName("LastName").
                IsRequired().
                HasMaxLength(Name.MAX_LENGTH);

            modelBuilder.OwnsMany(e => e.Incomes).OwnsOne(o => o.Income).
                Property(p => p.Value).
                HasColumnName("Income");

            modelBuilder.OwnsMany(e => e.Incomes).OwnsOne(o => o.SalaryDetails).OwnsOne(o => o.BasicSalary).
                Property(p => p.Value).
                HasColumnName("BasicSalary");

            modelBuilder.OwnsMany(e => e.Incomes).OwnsOne(o => o.SalaryDetails).OwnsOne(o => o.Allowance).
                Property(p => p.Value).
                HasColumnName("Allowance");

            modelBuilder.OwnsMany(e => e.Incomes).OwnsOne(o => o.SalaryDetails).OwnsOne(o => o.Transportation).
                Property(p => p.Value).
                HasColumnName("Transportation");

            modelBuilder.OwnsMany(e => e.Incomes).OwnsOne(o => o.Date).
                Property(p => p.GregorianDate).
                HasColumnName("Date");
        }
    }
}