using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPatternDemo.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnimalType",
                table: "Animals",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimalCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalFacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trivia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeSpan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalFacts_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFacts_AnimalId",
                table: "AnimalFacts",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalCategories_CategoryId",
                table: "Animals",
                column: "CategoryId",
                principalTable: "AnimalCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalCategories_CategoryId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalCategories");

            migrationBuilder.DropTable(
                name: "AnimalFacts");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Animals",
                newName: "AnimalType");
        }
    }
}
