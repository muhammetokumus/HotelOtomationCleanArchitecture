using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelOtomation.Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailImage",
                table: "Hotels",
                newName: "WebSiteUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebSiteUrl",
                table: "Hotels",
                newName: "DetailImage");
        }
    }
}
