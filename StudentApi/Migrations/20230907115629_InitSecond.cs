using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApi.Migrations
{
    public partial class InitSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "States",
                newName: "State_Name");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Cities",
                newName: "State_Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "City_Name");

            migrationBuilder.AddColumn<int>(
                name: "Country_Id",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country_Id",
                table: "States");

            migrationBuilder.RenameColumn(
                name: "State_Name",
                table: "States",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "State_Id",
                table: "Cities",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "City_Name",
                table: "Cities",
                newName: "Name");
        }
    }
}
