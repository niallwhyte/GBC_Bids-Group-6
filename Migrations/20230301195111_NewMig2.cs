using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBC_Bids_Group_6.Migrations
{
    public partial class NewMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Items",
                newName: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Items",
                newName: "Category");
        }
    }
}
