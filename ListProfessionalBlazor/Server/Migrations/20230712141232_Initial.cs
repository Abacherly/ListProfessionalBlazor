using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListProfessionalBlazor.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListProfessionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Years = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListProfessionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListProfessionals_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Home Office" });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Empresa" });

            migrationBuilder.InsertData(
                table: "ListProfessionals",
                columns: new[] { "Id", "Name", "Position", "WorkId", "Years" },
                values: new object[] { 1, "João", "Gerente", 1, "4" });

            migrationBuilder.InsertData(
                table: "ListProfessionals",
                columns: new[] { "Id", "Name", "Position", "WorkId", "Years" },
                values: new object[] { 2, "Maria", "Desenvolvedora Sênior", 2, "8" });

            migrationBuilder.CreateIndex(
                name: "IX_ListProfessionals_WorkId",
                table: "ListProfessionals",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListProfessionals");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
