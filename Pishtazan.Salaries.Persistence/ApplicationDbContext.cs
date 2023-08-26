using Microsoft.EntityFrameworkCore;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Employee>? Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            configureValueObjects(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeesConfig());
        }

        private static void configureValueObjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Owned<IncomeDetail>();
            modelBuilder.Owned<FullName>();
            modelBuilder.Owned<FirstName>();
            modelBuilder.Owned<LastName>();
            modelBuilder.Owned<Income>();
            modelBuilder.Owned<SalaryDetail>();
            modelBuilder.Owned<BasicSalary>();
            modelBuilder.Owned<Allowance>();
            modelBuilder.Owned<Transportation>();
            modelBuilder.Owned<Date>();
        }
    }
}
