using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelOtomation.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Hotels",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Hotels",
                newName: "Image");
        }
    }
}
