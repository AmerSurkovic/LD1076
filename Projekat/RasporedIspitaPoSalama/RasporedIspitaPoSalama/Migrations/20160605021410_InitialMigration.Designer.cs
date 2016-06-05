using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using RasporedIspitaPoSalama.SRSPS.Models;

namespace RasporedIspitaPoSalamaMigrations
{
    [ContextType(typeof(RasporedIspitaPoSalamaDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160605021410_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("RasporedIspitaPoSalama.SRSPS.Models.Predmet", b =>
                {
                    b.Property<int>("predmetID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("brojUpisanihStudenata");

                    b.Property<float>("ects");

                    b.Property<int>("godina");

                    b.Property<string>("naziv");

                    b.Property<int>("semestar");

                    b.Key("predmetID");
                });

            builder.Entity("RasporedIspitaPoSalama.SRSPS.Models.Sala", b =>
                {
                    b.Property<int>("salaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("kapacitet");

                    b.Property<string>("naziv");

                    b.Key("salaID");
                });

            builder.Entity("RasporedIspitaPoSalama.SRSPS.Models.Student", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("brojIndeksa");

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("prezime");

                    b.Key("studentID");
                });
        }
    }
}
