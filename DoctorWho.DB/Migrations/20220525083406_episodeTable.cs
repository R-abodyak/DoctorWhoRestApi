using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.DB.Migrations
{
    public partial class episodeTable:Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Authors_AuthorId" ,
                table: "Episodes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Doctors_DoctorNumber" ,
                table: "Doctors");


            migrationBuilder.AlterColumn<int>(
                name: "AuthorId" ,
                table: "Episodes" ,
                nullable: false ,
                oldClrType: typeof(int) ,
                oldType: "int" ,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 1 ,
                column: "AuthorId" ,
                value: 1);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 2 ,
                column: "AuthorId" ,
                value: 1);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 3 ,
                column: "AuthorId" ,
                value: 5);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 4 ,
                column: "AuthorId" ,
                value: 1);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 5 ,
                column: "AuthorId" ,
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Authors_AuthorId" ,
                table: "Episodes" ,
                column: "AuthorId" ,
                principalTable: "Authors" ,
                principalColumn: "AuthorId" ,
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Authors_AuthorId" ,
                table: "Episodes");



            migrationBuilder.AlterColumn<int>(
                name: "AuthorId" ,
                table: "Episodes" ,
                type: "int" ,
                nullable: true ,
                oldClrType: typeof(int));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Doctors_DoctorNumber" ,
                table: "Doctors" ,
                column: "DoctorNumber");

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 1 ,
                column: "AuthorId" ,
                value: null);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 2 ,
                column: "AuthorId" ,
                value: null);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 3 ,
                column: "AuthorId" ,
                value: null);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 4 ,
                column: "AuthorId" ,
                value: null);

            migrationBuilder.UpdateData(
                table: "Episodes" ,
                keyColumn: "EpisodeId" ,
                keyValue: 5 ,
                column: "AuthorId" ,
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Authors_AuthorId" ,
                table: "Episodes" ,
                column: "AuthorId" ,
                principalTable: "Authors" ,
                principalColumn: "AuthorId" ,
                onDelete: ReferentialAction.Restrict);
        }
    }
}
