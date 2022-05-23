using System;
using Microsoft. EntityFrameworkCore. Migrations;

namespace DoctorWho. DB. Migrations
    {
    public partial class init :Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder. CreateTable(
                name: "Authors" ,
                columns: table => new
                    {
                    AuthorId = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    AuthorName = table. Column<string>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_Authors" , x => x. AuthorId);
                });

            migrationBuilder. CreateTable(
                name: "Companions" ,
                columns: table => new
                    {
                    CompanionID = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    CompanionName = table. Column<string>(nullable: true) ,
                    WhoPlayed = table. Column<string>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_Companions" , x => x. CompanionID);
                });

            migrationBuilder. CreateTable(
                name: "Doctors" ,
                columns: table => new
                    {
                    DoctorId = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    DoctorNumber = table. Column<int>(nullable: false) ,
                    DoctorName = table. Column<string>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_Doctors" , x => x. DoctorId);
                    table. UniqueConstraint("AK_Doctors_DoctorNumber" , x => x. DoctorNumber);
                });

            migrationBuilder. CreateTable(
                name: "Enemy" ,
                columns: table => new
                    {
                    EnemyId = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    EnemyName = table. Column<string>(nullable: true) ,
                    Description = table. Column<string>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_Enemy" , x => x. EnemyId);
                });

            migrationBuilder. CreateTable(
                name: "Episodes" ,
                columns: table => new
                    {
                    EpisodeId = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    SeriesNumber = table. Column<int>(nullable: false) ,
                    EpisodeNumber = table. Column<int>(nullable: false) ,
                    EpisodeType = table. Column<string>(nullable: true) ,
                    Tittle = table. Column<string>(nullable: true) ,
                    EpisodeDate = table. Column<DateTime>(nullable: false) ,
                    Notes = table. Column<string>(nullable: true) ,
                    DoctorId = table. Column<int>(nullable: false) ,
                    AuthorId = table. Column<int>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_Episodes" , x => x. EpisodeId);
                    table. UniqueConstraint("AK_Episodes_SeriesNumber" , x => x. SeriesNumber);
                    table. ForeignKey(
                        name: "FK_Episodes_Authors_AuthorId" ,
                        column: x => x. AuthorId ,
                        principalTable: "Authors" ,
                        principalColumn: "AuthorId" ,
                        onDelete: ReferentialAction. Restrict);
                    table. ForeignKey(
                        name: "FK_Episodes_Doctors_DoctorId" ,
                        column: x => x. DoctorId ,
                        principalTable: "Doctors" ,
                        principalColumn: "DoctorId" ,
                        onDelete: ReferentialAction. Cascade);
                });

            migrationBuilder. CreateTable(
                name: "EpisodeCompanion" ,
                columns: table => new
                    {
                    EpisodeCompanionId = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    EpisodeId = table. Column<int>(nullable: true) ,
                    CompanionID = table. Column<int>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_EpisodeCompanion" , x => x. EpisodeCompanionId);
                    table. ForeignKey(
                        name: "FK_EpisodeCompanion_Companions_CompanionID" ,
                        column: x => x. CompanionID ,
                        principalTable: "Companions" ,
                        principalColumn: "CompanionID" ,
                        onDelete: ReferentialAction. Restrict);
                    table. ForeignKey(
                        name: "FK_EpisodeCompanion_Episodes_EpisodeId" ,
                        column: x => x. EpisodeId ,
                        principalTable: "Episodes" ,
                        principalColumn: "EpisodeId" ,
                        onDelete: ReferentialAction. Restrict);
                });

            migrationBuilder. CreateTable(
                name: "EpisodeEnemy" ,
                columns: table => new
                    {
                    EpisodeEnemyId = table. Column<int>(nullable: false)
                        . Annotation("SqlServer:Identity" , "1, 1") ,
                    EpisodeId = table. Column<int>(nullable: false) ,
                    CompanionID = table. Column<int>(nullable: false) ,
                    EnemyId = table. Column<int>(nullable: true)
                    } ,
                constraints: table =>
                {
                    table. PrimaryKey("PK_EpisodeEnemy" , x => x. EpisodeEnemyId);
                    table. ForeignKey(
                        name: "FK_EpisodeEnemy_Enemy_EnemyId" ,
                        column: x => x. EnemyId ,
                        principalTable: "Enemy" ,
                        principalColumn: "EnemyId" ,
                        onDelete: ReferentialAction. Restrict);
                    table. ForeignKey(
                        name: "FK_EpisodeEnemy_Episodes_EpisodeId" ,
                        column: x => x. EpisodeId ,
                        principalTable: "Episodes" ,
                        principalColumn: "EpisodeId" ,
                        onDelete: ReferentialAction. Cascade);
                });

            migrationBuilder. CreateIndex(
                name: "IX_EpisodeCompanion_CompanionID" ,
                table: "EpisodeCompanion" ,
                column: "CompanionID");

            migrationBuilder. CreateIndex(
                name: "IX_EpisodeCompanion_EpisodeId" ,
                table: "EpisodeCompanion" ,
                column: "EpisodeId");

            migrationBuilder. CreateIndex(
                name: "IX_EpisodeEnemy_EnemyId" ,
                table: "EpisodeEnemy" ,
                column: "EnemyId");

            migrationBuilder. CreateIndex(
                name: "IX_EpisodeEnemy_EpisodeId" ,
                table: "EpisodeEnemy" ,
                column: "EpisodeId");

            migrationBuilder. CreateIndex(
                name: "IX_Episodes_AuthorId" ,
                table: "Episodes" ,
                column: "AuthorId");

            migrationBuilder. CreateIndex(
                name: "IX_Episodes_DoctorId" ,
                table: "Episodes" ,
                column: "DoctorId");

            migrationBuilder. CreateIndex(
                name: "IX_Episodes_EpisodeNumber" ,
                table: "Episodes" ,
                column: "EpisodeNumber" ,
                unique: true);
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder. DropTable(
                name: "EpisodeCompanion");

            migrationBuilder. DropTable(
                name: "EpisodeEnemy");

            migrationBuilder. DropTable(
                name: "Companions");

            migrationBuilder. DropTable(
                name: "Enemy");

            migrationBuilder. DropTable(
                name: "Episodes");

            migrationBuilder. DropTable(
                name: "Authors");

            migrationBuilder. DropTable(
                name: "Doctors");
            }
        }
    }
