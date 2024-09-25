using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAtrioEmployeManagement.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPersonne",
                table: "Emploi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPersonne",
                table: "Emploi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
