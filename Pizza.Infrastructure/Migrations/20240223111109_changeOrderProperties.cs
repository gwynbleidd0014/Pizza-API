using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.Infrastructure.Migrations
{
    public partial class changeOrderProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pizza",
                table: "OrderM",
                newName: "PizzaId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderM",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderM_PizzaId",
                table: "OrderM",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderM_Pizzas_PizzaId",
                table: "OrderM",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderM_Pizzas_PizzaId",
                table: "OrderM");

            migrationBuilder.DropIndex(
                name: "IX_OrderM_PizzaId",
                table: "OrderM");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderM");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "OrderM",
                newName: "Pizza");
        }
    }
}
