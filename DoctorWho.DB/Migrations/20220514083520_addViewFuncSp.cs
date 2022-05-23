using Microsoft. EntityFrameworkCore. Migrations;

namespace DoctorWho. DB. Migrations
    {
    public partial class addViewFuncSp :Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {

            migrationBuilder. Sql(
                @"Create FUNCTION fnEnemies (@EpisodeId int)
Returns VARCHAR(100) as 
begin
DECLARE @Names VARCHAR(100)  
SELECT @Names = COALESCE(@Names + ', ', '') + [EnemyName] 
From [DoctorWhoCore].[dbo].[Enemy]
inner join [DoctorWhoCore].[dbo].[EpisodeEnemy] on
[Enemy].EnemyId=[EpisodeEnemy].EnemyID
WHERE [EpisodeEnemy].EpisodeId=@EpisodeId
return @Names
end;");
            migrationBuilder. Sql(@"Create FUNCTION fnCompanion (@EpisodeId int)
Returns VARCHAR(100) as 
begin
DECLARE @Names VARCHAR(100)  
SELECT @Names = COALESCE(@Names + ', ', '') + [CompanionName] 
From [DoctorWhoCore].[dbo].[Companions]
inner join [DoctorWhoCore].[dbo].[EpisodeCompanion] on
 [Companions].CompanionID=[EpisodeCompanion].CompanionID
WHERE [DBO].[EpisodeCompanion].EpisodeId=@EpisodeId
return @Names
end;");
            migrationBuilder. Sql(@"CREATE VIEW viewEpisodes as
SELECT A.AuthorName, D.DoctorName, dbo.fnEnemies(E.EpisodeId) AS EnemiesNames ,dbo.fnCompanion(E.EpisodeId) as CompanionsNames
FROM dbo.Episodes AS E INNER JOIN
                         dbo.Authors AS A ON E.AuthorId = A.AuthorId INNER JOIN
                         dbo.Doctors AS D ON E.DoctorId = D.DoctorId");

            migrationBuilder. Sql(@"
  create Procedure spSummariseEpisodes
  as
   select   Top(3)c.CompanionID ,c.CompanionName,c.WhoPlayed,(c.CompanionID)
  From Companions as c
  inner join EpisodeCompanion as ec
  on  c.CompanionID=ec.CompanionID
  Group by c.CompanionID,c.CompanionName,c.WhoPlayed
  order by Count(c.CompanionID) desc

  select E.EnemyId,E.EnemyName,E.Description , COUNT(E.EnemyID) as countt
  from Enemy AS E
  inner join EpisodeEnemy AS EE
  on E.EnemyId=EE.EnemyID
  GROUP BY E.EnemyId,E.EnemyName,E.Description
   ORDER BY COUNT(E.EnemyID)  DESC

");
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder. Sql(@"DROP FUNCTION fnEnemies;
                                    DROP FUNCTION fnCompanion;
                                    DROP VIEW viewEpisodes;
                                    DROP PROCEDURE spSummariseEpisodes;



");
            }
        }
    }
