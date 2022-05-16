using Microsoft.EntityFrameworkCore.Migrations;

namespace Planpinterview.Migrations
{
    public partial class filter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"create proc getfilterresultsp
                       @startdate datetime,
                       @enddate datetime
                       as
                       select p.name,p.address,p.date,p.monyvalue,c.name from players p
                       join categprogram c
                       on p.categprogramid = c.id
                       where date between @startdate  and @enddate ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
