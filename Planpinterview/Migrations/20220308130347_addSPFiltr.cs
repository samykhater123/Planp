using Microsoft.EntityFrameworkCore.Migrations;

namespace Planpinterview.Migrations
{
    public partial class addSPFiltr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"create proc totalmonysp
                        as
                       select sum(monyvalue) from players";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
