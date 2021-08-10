using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveWebsite.Database.Migrations
{
    public partial class ClaimsSettings_Home_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClaimsSettings",
                columns: new[] { "Id", "MinLevel" },
                values: new object[] { "Home", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimsSettings",
                keyColumn: "Id",
                keyValue: "Home");
        }
    }
}
