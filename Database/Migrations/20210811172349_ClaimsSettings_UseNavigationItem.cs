using InteractiveWebsite.Common.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveWebsite.Database.Migrations
{
    public partial class ClaimsSettings_UseNavigationItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimsSettings",
                table: "ClaimsSettings");

            migrationBuilder.DeleteData(
                table: "ClaimsSettings",
                keyColumn: "Id",
                keyValue: "Home");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:navigation_item", "home,members,news");

            migrationBuilder.AddColumn<NavigationItem>(
                name: "Navigation",
                table: "ClaimsSettings",
                type: "navigation_item",
                nullable: false,
                defaultValue: NavigationItem.Home);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimsSettings",
                table: "ClaimsSettings",
                columns: new[] { "Id", "Navigation" });

            migrationBuilder.InsertData(
                table: "ClaimsSettings",
                columns: new[] { "Id", "Navigation", "MinLevel" },
                values: new object[] { "Home", NavigationItem.Home, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsSettings_Navigation",
                table: "ClaimsSettings",
                column: "Navigation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimsSettings",
                table: "ClaimsSettings");

            migrationBuilder.DropIndex(
                name: "IX_ClaimsSettings_Navigation",
                table: "ClaimsSettings");

            migrationBuilder.DropColumn(
                name: "Navigation",
                table: "ClaimsSettings");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:navigation_item", "home,members,news");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimsSettings",
                table: "ClaimsSettings",
                column: "Id");
        }
    }
}
