using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pcshopbackend.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prebuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prebuilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrebuildID = table.Column<int>(type: "int", nullable: true),
                    PartCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_PartCategories_PartCategoryID",
                        column: x => x.PartCategoryID,
                        principalTable: "PartCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Prebuilds_PrebuildID",
                        column: x => x.PrebuildID,
                        principalTable: "Prebuilds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartCategoryID",
                table: "Parts",
                column: "PartCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PrebuildID",
                table: "Parts",
                column: "PrebuildID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "PartCategories");

            migrationBuilder.DropTable(
                name: "Prebuilds");
        }
    }
}
