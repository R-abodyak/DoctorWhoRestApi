using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.DB.Migrations
{
    public partial class discover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Enemy",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[] { 8, "this is description22", "enemy2" });

            migrationBuilder.InsertData(
                table: "EpisodeEnemy",
                columns: new[] { "EpisodeEnemyId", "EnemyID", "EpisodeId" },
                values: new object[] { 9, 8, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enemy",
                keyColumn: "EnemyId",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Enemy",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[] { 2, "this is description", "enemy1" });
        }
    }
}
