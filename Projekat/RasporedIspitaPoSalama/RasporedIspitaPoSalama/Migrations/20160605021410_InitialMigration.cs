using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace RasporedIspitaPoSalamaMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    predmetID = table.Column(type: "INTEGER", nullable: false),
                    brojUpisanihStudenata = table.Column(type: "INTEGER", nullable: false),
                    ects = table.Column(type: "REAL", nullable: false),
                    godina = table.Column(type: "INTEGER", nullable: false),
                    naziv = table.Column(type: "TEXT", nullable: true),
                    semestar = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.predmetID);
                });
            migration.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    salaID = table.Column(type: "INTEGER", nullable: false),
                    kapacitet = table.Column(type: "INTEGER", nullable: false),
                    naziv = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.salaID);
                });
            migration.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentID = table.Column(type: "INTEGER", nullable: false),
                    brojIndeksa = table.Column(type: "INTEGER", nullable: false),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Predmet");
            migration.DropTable("Sala");
            migration.DropTable("Student");
        }
    }
}
