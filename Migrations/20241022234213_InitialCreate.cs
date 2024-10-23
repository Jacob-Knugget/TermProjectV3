using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BodyGroupId = table.Column<int>(type: "int", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plan_BodyGroup_BodyGroupId",
                        column: x => x.BodyGroupId,
                        principalTable: "BodyGroup",
                        principalColumn: "BodyGroupId");
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

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "ID", "BodyGroupId", "Name", "Reps", "Sets", "Weight" },
                values: new object[] { 1, 1, "Barbell Bench Press", 12, 4, 200 });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "ID", "BodyGroupId", "Name", "Reps", "Sets", "Weight" },
                values: new object[] { 2, 1, "Dumbbell Fly", 12, 4, 40 });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "ID", "BodyGroupId", "Name", "Reps", "Sets", "Weight" },
                values: new object[] { 3, 3, "Skullcrusher", 12, 4, 30 });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_BodyGroupId",
                table: "Plan",
                column: "BodyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "BodyGroup");
        }
    }
}
