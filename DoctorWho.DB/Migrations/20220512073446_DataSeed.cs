using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.DB.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Mohamed" },
                    { 2, "Ahmed" },
                    { 3, "Aseel" },
                    { 4, "Omar" },
                    { 5, "Marwa" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionID", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 4, "NAME4", "W4" },
                    { 3, "NAME3", "W3" },
                    { 5, "NAME5", "W5" },
                    { 1, "NAME1", "W1" },
                    { 2, "NAME2", "W2" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hani", 1, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1970, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huda", 2, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1978, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nada", 3, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1978, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", 4, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1978, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "salam", 5, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemy",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 4, "this is description", "enemy1" },
                    { 1, "this is description", "enemy1" },
                    { 2, "this is description", "enemy1" },
                    { 3, "this is description", "enemy1" },
                    { 5, "this is description", "enemy1" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Tittle" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2018, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "type1", null, 1, "tittle1" },
                    { 2, null, 1, new DateTime(2022, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "type1", null, 165, "tittle2" },
                    { 3, null, 1, new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "type1", "notes3", 188, "tittle1" },
                    { 4, null, 2, new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "type3", "notes4", 189, "tittle4" },
                    { 5, null, 3, new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "type2", "notes5", 181, "tittle5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);
        }
    }
}
