using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.Infrastructure.Migrations
{
    public partial class fixDbsetOrderM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserM_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderM_Addresses_AddressId",
                table: "OrderM");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderM_Pizzas_PizzaId",
                table: "OrderM");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderM_UserM_UserId",
                table: "OrderM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserM",
                table: "UserM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderM",
                table: "OrderM");

            migrationBuilder.RenameTable(
                name: "UserM",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "OrderM",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderM_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderM_PizzaId",
                table: "Orders",
                newName: "IX_Orders_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderM_AddressId",
                table: "Orders",
                newName: "IX_Orders_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pizzas_PizzaId",
                table: "Orders",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pizzas_PizzaId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserM");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderM");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "OrderM",
                newName: "IX_OrderM_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PizzaId",
                table: "OrderM",
                newName: "IX_OrderM_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AddressId",
                table: "OrderM",
                newName: "IX_OrderM_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserM",
                table: "UserM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderM",
                table: "OrderM",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserM_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "UserM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderM_Addresses_AddressId",
                table: "OrderM",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderM_Pizzas_PizzaId",
                table: "OrderM",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderM_UserM_UserId",
                table: "OrderM",
                column: "UserId",
                principalTable: "UserM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
