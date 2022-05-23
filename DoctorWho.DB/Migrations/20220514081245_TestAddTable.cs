using Microsoft. EntityFrameworkCore. Migrations;

namespace DoctorWho. DB. Migrations
    {
    public partial class TestAddTable :Migration
        {
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder. Sql(
@"EXEC('CREATE FUNCTION  [AgeAtDate] (@birthDate DATETIME, @passedDate DATETIME) RETURNS INT
    AS
    BEGIN
        DECLARE @iMonthDayBirthDate INT
        DECLARE @iMonthDayPassedDate INT

        SELECT @iMonthDayBirthDate = CAST( DATEPART(mm, @birthDate)*100 + DATEPART(dd, @birthDate) AS INT)
        SELECT @iMonthDayPassedDate = CAST( DATEPART(mm, @passedDate)*100 + DATEPART(dd, @passedDate) AS INT)

        RETURN DATEDIFF(yy, @birthDate, @passedDate)
            - CASE WHEN @iMonthDayBirthDate <= @iMonthDayPassedDate
                THEN 0
                ELSE 1
              END
    END')");

            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder. Sql(@"DROP FUNCTION [AgeAtDate]");

            }
        }
    }
