using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TodoApi.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    std_Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    std_fname = table.Column<string>(nullable: true),
                    std_lname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.std_Id);
                });

            migrationBuilder.CreateTable(
                name: "Universitys",
                columns: table => new
                {
                    uni_Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uni_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universitys", x => x.uni_Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentinUniversities",
                columns: table => new
                {
                    std_id = table.Column<int>(nullable: false),
                    uni_id = table.Column<int>(nullable: false),
                    Studentstd_Id = table.Column<long>(nullable: true),
                    Universityuni_Id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentinUniversities", x => new { x.std_id, x.uni_id });
                    table.ForeignKey(
                        name: "FK_StudentinUniversities_Students_Studentstd_Id",
                        column: x => x.Studentstd_Id,
                        principalTable: "Students",
                        principalColumn: "std_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentinUniversities_Universitys_Universityuni_Id",
                        column: x => x.Universityuni_Id,
                        principalTable: "Universitys",
                        principalColumn: "uni_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentinUniversities_Studentstd_Id",
                table: "StudentinUniversities",
                column: "Studentstd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentinUniversities_Universityuni_Id",
                table: "StudentinUniversities",
                column: "Universityuni_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentinUniversities");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Universitys");
        }
    }
}
