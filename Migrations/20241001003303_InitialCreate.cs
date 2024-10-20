using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "ID", "Name", "Reps", "Sets", "Weight" },
                values: new object[] { 1, "Barbell Bench Press", 12, 4, 200 });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "ID", "Name", "Reps", "Sets", "Weight" },
                values: new object[] { 2, "Dumbbell Fly", 12, 4, 40 });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "ID", "Name", "Reps", "Sets", "Weight" },
                values: new object[] { 3, "Skullcrusher", 12, 4, 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
