using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietitianwebsite.Data.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    breakfast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lunch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dinner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_Program_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Program_userid",
                table: "Program",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Program");
        }
    }
}
