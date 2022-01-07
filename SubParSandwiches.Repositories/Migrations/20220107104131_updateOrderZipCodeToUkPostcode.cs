using Microsoft.EntityFrameworkCore.Migrations;

namespace SubParSandwiches.Repositories.Migrations
{
    public partial class updateOrderZipCodeToUkPostcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Orders",
                newName: "PostCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Orders",
                newName: "ZipCode");
        }
    }
}
