using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWeb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klassenraeume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RaumInQm = table.Column<float>(type: "REAL", nullable: false),
                    Plaetze = table.Column<int>(type: "INTEGER", nullable: false),
                    HasCynap = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klassenraeume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lehrer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Kuerzel = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    BildUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Fachbereich = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Erfahrung = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    IstKlassenlehrer = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Geschlecht = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Geburtstag = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lehrer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klassen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Bezeichnung = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Schulstufe = table.Column<int>(type: "INTEGER", nullable: false),
                    Ausbildungsrichtung = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    KlassenlehrerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klassen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klassen_Lehrer_KlassenlehrerId",
                        column: x => x.KlassenlehrerId,
                        principalTable: "Lehrer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Schueler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Klasse = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    KlasseId = table.Column<int>(type: "INTEGER", nullable: true),
                    Geschlecht = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Geburtstag = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schueler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schueler_Klassen_KlasseId",
                        column: x => x.KlasseId,
                        principalTable: "Klassen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchuelerKlassenraeume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchuelerId = table.Column<int>(type: "INTEGER", nullable: false),
                    KlassenraumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchuelerKlassenraeume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchuelerKlassenraeume_Klassenraeume_KlassenraumId",
                        column: x => x.KlassenraumId,
                        principalTable: "Klassenraeume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchuelerKlassenraeume_Schueler_SchuelerId",
                        column: x => x.SchuelerId,
                        principalTable: "Schueler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klassen_KlassenlehrerId",
                table: "Klassen",
                column: "KlassenlehrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Klassen_Name",
                table: "Klassen",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lehrer_Email",
                table: "Lehrer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lehrer_Kuerzel",
                table: "Lehrer",
                column: "Kuerzel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schueler_Geburtstag_Klasse",
                table: "Schueler",
                columns: new[] { "Geburtstag", "Klasse" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schueler_KlasseId",
                table: "Schueler",
                column: "KlasseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchuelerKlassenraeume_KlassenraumId",
                table: "SchuelerKlassenraeume",
                column: "KlassenraumId");

            migrationBuilder.CreateIndex(
                name: "IX_SchuelerKlassenraeume_SchuelerId",
                table: "SchuelerKlassenraeume",
                column: "SchuelerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchuelerKlassenraeume");

            migrationBuilder.DropTable(
                name: "Klassenraeume");

            migrationBuilder.DropTable(
                name: "Schueler");

            migrationBuilder.DropTable(
                name: "Klassen");

            migrationBuilder.DropTable(
                name: "Lehrer");
        }
    }
}
