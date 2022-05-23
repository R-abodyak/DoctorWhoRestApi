using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.DB.Migrations
{
    public partial class fkfixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeCompanion_Companions_CompanionID",
                table: "EpisodeCompanion");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeCompanion_Episodes_EpisodeId",
                table: "EpisodeCompanion");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeId",
                table: "EpisodeCompanion",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanionID",
                table: "EpisodeCompanion",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeCompanion_Companions_CompanionID",
                table: "EpisodeCompanion",
                column: "CompanionID",
                principalTable: "Companions",
                principalColumn: "CompanionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeCompanion_Episodes_EpisodeId",
                table: "EpisodeCompanion",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "EpisodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeCompanion_Companions_CompanionID",
                table: "EpisodeCompanion");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeCompanion_Episodes_EpisodeId",
                table: "EpisodeCompanion");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeId",
                table: "EpisodeCompanion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanionID",
                table: "EpisodeCompanion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeCompanion_Companions_CompanionID",
                table: "EpisodeCompanion",
                column: "CompanionID",
                principalTable: "Companions",
                principalColumn: "CompanionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeCompanion_Episodes_EpisodeId",
                table: "EpisodeCompanion",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "EpisodeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
