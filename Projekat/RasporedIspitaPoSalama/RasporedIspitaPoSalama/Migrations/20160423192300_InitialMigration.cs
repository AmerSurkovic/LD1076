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
                       // .Annotation("Sqlite:Autoincrement", true),
                    naziv = table.Column(type: "TEXT", nullable: true)
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
                     //   .Annotation("Sqlite:Autoincrement", true),
                    brojPrijavljenih = table.Column(type: "INTEGER", nullable: false),
                    kapacitet = table.Column(type: "INTEGER", nullable: false),
                    naziv = table.Column(type: "TEXT", nullable: true),
                    povrsina = table.Column(type: "REAL", nullable: false),
                    trenutnaTemperatura = table.Column(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.salaID);
                });
            migration.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    TerminID = table.Column(type: "INTEGER", nullable: false),
                    //    .Annotation("Sqlite:Autoincrement", true),
                    SalasalaID = table.Column(type: "INTEGER", nullable: true),
                    predmetpredmetID = table.Column(type: "INTEGER", nullable: true),
                    vrijemePocetka = table.Column(type: "TEXT", nullable: false),
                    vrijemeZavrsetka = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.TerminID);
                    table.ForeignKey(
                        name: "FK_Termin_Sala_SalasalaID",
                        columns: x => x.SalasalaID,
                        referencedTable: "Sala",
                        referencedColumn: "salaID");
                    table.ForeignKey(
                        name: "FK_Termin_Predmet_predmetpredmetID",
                        columns: x => x.predmetpredmetID,
                        referencedTable: "Predmet",
                        referencedColumn: "predmetID");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Termin");
            migration.DropTable("Sala");
            migration.DropTable("Predmet");
        }
    }
}
