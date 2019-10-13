using Microsoft.EntityFrameworkCore.Migrations;

namespace InciCafe.DAL.Migrations
{
    public partial class adjust_naming_order_table_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Name",
                table: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Status",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Status_Name",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
