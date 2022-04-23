using Microsoft.EntityFrameworkCore.Migrations;

namespace _08_DosyaRepository.Migrations
{
    public partial class testadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "Kisiler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "Kisiler");
        }
    }
}
