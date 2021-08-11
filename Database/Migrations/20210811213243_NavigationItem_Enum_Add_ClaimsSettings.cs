using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveWebsite.Database.Migrations
{
    public partial class NavigationItem_Enum_Add_ClaimsSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:navigation_item", "home,members,news,claims_settings")
                .OldAnnotation("Npgsql:Enum:navigation_item", "home,members,news");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:navigation_item", "home,members,news")
                .OldAnnotation("Npgsql:Enum:navigation_item", "home,members,news,claims_settings");
        }
    }
}
