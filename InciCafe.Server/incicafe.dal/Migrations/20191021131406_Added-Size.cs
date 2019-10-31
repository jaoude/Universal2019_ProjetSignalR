using Microsoft.EntityFrameworkCore.Migrations;

namespace InciCafe.DAL.Migrations
{
    public partial class AddedSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Order");
        }
    }
}
