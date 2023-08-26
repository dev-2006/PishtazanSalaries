using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pishtazan.Salaries.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName_FirstName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName_LastName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "IncomeDetail",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_GregorianDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryDetails_BasicSalary_Value = table.Column<long>(type: "bigint", nullable: false),
                    SalaryDetails_Allowance_Value = table.Column<long>(type: "bigint", nullable: false),
                    SalaryDetails_Transportation_Value = table.Column<long>(type: "bigint", nullable: false),
                    Income_Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeDetail", x => new { x.EmployeeId, x.Id });
                    table.ForeignKey(
                        name: "FK_IncomeDetail_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeDetail");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
