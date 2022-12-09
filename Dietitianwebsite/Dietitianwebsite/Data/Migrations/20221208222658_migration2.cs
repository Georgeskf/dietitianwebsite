using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietitianwebsite.Data.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Food",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Food_userid",
                table: "Food",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_AspNetUsers_userid",
                table: "Food",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_AspNetUsers_userid",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_userid",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
