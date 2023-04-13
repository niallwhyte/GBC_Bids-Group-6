using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBC_Bids_Group_6.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConditionID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentPrice",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ConditionID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Items");
        }
    }
}
