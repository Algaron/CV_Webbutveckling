using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_Webbutveckling.Migrations
{
    public partial class longertexts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "WorkExperience",
                type: "Nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WorkExperience",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "WorkExperience",
                type: "Nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "WorkExperience",
                type: "Nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WorkExperience",
                type: "Nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "WorkExperience",
                type: "Nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(255)");
        }
    }
}
