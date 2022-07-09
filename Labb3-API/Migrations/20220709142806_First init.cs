using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb3_API.Migrations
{
    public partial class Firstinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(nullable: true),
                    HobbyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbies",
                columns: table => new
                {
                    PersonHobbyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbies", x => x.PersonHobbyId);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, " the practice of applying paint, pigment, color or other medium to a solid surface", "Painting" },
                    { 2, "the art, science and craft of using heat to prepare food for consumption", "Cooking" },
                    { 3, "develop specific motor skills, agility, strength or physical fitness", "Training" },
                    { 4, " the art of arranging sound", "Music" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Samira", "Ekberg", "0738041775" },
                    { 2, "Nick", "Larsson", "07226566888" },
                    { 3, "Ingrid", "Johansson", "0703698366" },
                    { 4, "Magnus", "Lund", "0737659489" },
                    { 5, "Nelly", "Stenberg", "0718763244" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "HobbyId", "PersonId", "URL" },
                values: new object[,]
                {
                    { 3, 3, 1, "https://en.wikipedia.org/wiki/Training" },
                    { 5, 4, 2, "https://www.newworldencyclopedia.org/entry/Music" },
                    { 2, 2, 3, "https://en.wikipedia.org/wiki/Cooking" },
                    { 1, 1, 4, "https://en.wikipedia.org/wiki/Painting" },
                    { 4, 4, 5, "https://en.wikipedia.org/wiki/Music" }
                });

            migrationBuilder.InsertData(
                table: "PersonHobbies",
                columns: new[] { "PersonHobbyId", "HobbyId", "PersonId" },
                values: new object[,]
                {
                    { 3, 3, 1 },
                    { 7, 2, 1 },
                    { 5, 4, 2 },
                    { 6, 3, 2 },
                    { 2, 2, 3 },
                    { 1, 1, 4 },
                    { 4, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_HobbyId",
                table: "Links",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_HobbyId",
                table: "PersonHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_PersonId",
                table: "PersonHobbies",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonHobbies");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
