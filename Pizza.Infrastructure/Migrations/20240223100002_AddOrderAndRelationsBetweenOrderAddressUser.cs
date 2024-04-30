using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.Infrastructure.Migrations
{
    public partial class AddOrderAndRelationsBetweenOrderAddressUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserM",
                table: "UserM",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Pizza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderM_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderM_UserM_UserId",
                        column: x => x.UserId,
                        principalTable: "UserM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderM_AddressId",
                table: "OrderM",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderM_UserId",
                table: "OrderM",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserM_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "UserM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserM_UserId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "OrderM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserM",
                table: "UserM");

            migrationBuilder.RenameTable(
                name: "UserM",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
