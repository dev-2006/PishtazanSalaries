using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pishtazan.Salaries.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalaryDetails_Transportation_Value",
                table: "IncomeDetail",
                newName: "Transportation");

            migrationBuilder.RenameColumn(
                name: "SalaryDetails_BasicSalary_Value",
                table: "IncomeDetail",
                newName: "Income");

            migrationBuilder.RenameColumn(
                name: "SalaryDetails_Allowance_Value",
                table: "IncomeDetail",
                newName: "BasicSalary");

            migrationBuilder.RenameColumn(
                name: "Income_Value",
                table: "IncomeDetail",
                newName: "Allowance");

            migrationBuilder.RenameColumn(
                name: "Date_GregorianDate",
                table: "IncomeDetail",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "FullName_LastName_Value",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName_Value",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transportation",
                table: "IncomeDetail",
                newName: "SalaryDetails_Transportation_Value");

            migrationBuilder.RenameColumn(
                name: "Income",
                table: "IncomeDetail",
                newName: "SalaryDetails_BasicSalary_Value");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "IncomeDetail",
                newName: "Date_GregorianDate");

            migrationBuilder.RenameColumn(
                name: "BasicSalary",
                table: "IncomeDetail",
                newName: "SalaryDetails_Allowance_Value");

            migrationBuilder.RenameColumn(
                name: "Allowance",
                table: "IncomeDetail",
                newName: "Income_Value");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "FullName_LastName_Value");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employees",
                newName: "FullName_FirstName_Value");

            migrationBuilder.AlterColumn<string>(
                name: "FullName_LastName_Value",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FullName_FirstName_Value",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
