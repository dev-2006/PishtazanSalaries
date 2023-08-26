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
        }

        private static void configureShadowPropertyForKey(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder.Property<int>("EmployeeId");
            modelBuilder.HasKey("EmployeeId");
        }
    }
}