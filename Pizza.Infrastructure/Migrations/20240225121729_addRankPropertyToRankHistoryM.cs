using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.Infrastructure.Migrations
{
    public partial class addRankPropertyToRankHistoryM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rank",
                table: "RankHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "RankHistories");
        }
    }
}
