using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.DB.Migrations
{
    public partial class funcmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeylessEntity",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeylessEntity");
        }
    }
}
