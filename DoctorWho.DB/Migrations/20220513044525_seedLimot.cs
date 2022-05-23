using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.DB.Migrations
{
    public partial class seedLimot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeEnemy_Enemy_EnemyId",
                table: "EpisodeEnemy");

            migrationBuilder.DropColumn(
                name: "CompanionID",
                table: "EpisodeEnemy");

            migrationBuilder.RenameColumn(
                name: "EnemyId",
                table: "EpisodeEnemy",
                newName: "EnemyID");

            migrationBuilder.RenameIndex(
                name: "IX_EpisodeEnemy_EnemyId",
                table: "EpisodeEnemy",
                newName: "IX_EpisodeEnemy_EnemyID");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyID",
                table: "EpisodeEnemy",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeEnemy_Enemy_EnemyID",
                table: "EpisodeEnemy",
                column: "EnemyID",
                principalTable: "Enemy",
                principalColumn: "EnemyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeEnemy_Enemy_EnemyID",
                table: "EpisodeEnemy");

            migrationBuilder.RenameColumn(
                name: "EnemyID",
                table: "EpisodeEnemy",
                newName: "EnemyId");

            migrationBuilder.RenameIndex(
                name: "IX_EpisodeEnemy_EnemyID",
                table: "EpisodeEnemy",
                newName: "IX_EpisodeEnemy_EnemyId");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyId",
                table: "EpisodeEnemy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanionID",
                table: "EpisodeEnemy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeEnemy_Enemy_EnemyId",
                table: "EpisodeEnemy",
                column: "EnemyId",
                principalTable: "Enemy",
                principalColumn: "EnemyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
