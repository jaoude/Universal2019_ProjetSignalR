using Microsoft.EntityFrameworkCore.Migrations;

namespace InciCafe.DAL.Migrations
{
    public partial class adjust_naming_order_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Client_Client_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coffee_Coffee_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Status_Status_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Client_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Coffee_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Status_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Client_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Coffee_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status_Id",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoffeeId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CoffeeId",
                table: "Orders",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Client_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coffee_CoffeeId",
                table: "Orders",
                column: "CoffeeId",
                principalTable: "Coffee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Status_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Client_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coffee_CoffeeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Status_StatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CoffeeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CoffeeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Client_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Coffee_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Client_Id",
                table: "Orders",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Coffee_Id",
                table: "Orders",
                column: "Coffee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status_Id",
                table: "Orders",
                column: "Status_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Client_Client_Id",
                table: "Orders",
                column: "Client_Id",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coffee_Coffee_Id",
                table: "Orders",
                column: "Coffee_Id",
                principalTable: "Coffee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Status_Status_Id",
                table: "Orders",
                column: "Status_Id",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
