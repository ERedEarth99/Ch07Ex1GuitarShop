using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarShop.Migrations
{
    public partial class AddIsStringedInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStringedInstrument",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStringedInstrument",
                table: "Categories");
        }
    }
}
