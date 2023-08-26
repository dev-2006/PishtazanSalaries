using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pishtazan.Salaries.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqIndexToFirstAndLastNameColumns : Migration
    {
        private const string FIRST_LAST_NAME_INDEX = "IX_F_L_NAME";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(name: FIRST_LAST_NAME_INDEX, table: "Employees",
                columns: new string[] { "FirstName", "LastName" }, unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(FIRST_LAST_NAME_INDEX);
        }
    }
}
