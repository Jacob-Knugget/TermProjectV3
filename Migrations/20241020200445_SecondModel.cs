using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class SecondModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyGroupId",
                table: "Plan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BodyGroup",
                columns: table => new
                {
                    BodyGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyGroup", x => x.BodyGroupId);
                });

            migrationBuilder.InsertData(
                table: "BodyGroup",
                columns: new[] { "BodyGroupId", "BodyGroupName" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Back" },
                    { 3, "Arms" },
                    { 4, "Legs" }
                });

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "ID",
                keyValue: 1,
                column: "BodyGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "ID",
                keyValue: 2,
                column: "BodyGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "ID",
                keyValue: 3,
                column: "BodyGroupId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_BodyGroupId",
                table: "Plan",
                column: "BodyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_BodyGroup_BodyGroupId",
                table: "Plan",
                column: "BodyGroupId",
                principalTable: "BodyGroup",
                principalColumn: "BodyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_BodyGroup_BodyGroupId",
                table: "Plan");

            migrationBuilder.DropTable(
                name: "BodyGroup");

            migrationBuilder.DropIndex(
                name: "IX_Plan_BodyGroupId",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "BodyGroupId",
                table: "Plan");
        }
    }
}
