using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using RasporedIspitaPoSalama.SRSPS.Models;

namespace RasporedIspitaPoSalamaMigrations
{
    [ContextType(typeof(RasporedIspitaPoSalamaDbContext))]
    partial class RasporedIspitaPoSalamaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Predmet", b =>
                {
                    b.Property<int>("predmetID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("naziv");

                    b.Property<int>("godina");

                    b.Property<string>("semestar");

                    b.Property<string>("ects");

                    b.Property<string>("brojPrijavljenihStudenata");

                    b.Key("predmetID");
                });

            builder.Entity("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Sala", b =>
                {
                    b.Property<int>("salaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("brojPrijavljenih");

                    b.Property<int>("kapacitet");

                    b.Property<string>("naziv");

                    b.Property<float>("povrsina");

                    b.Property<float>("trenutnaTemperatura");

                    b.Key("salaID");
                });

            builder.Entity("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Termin", b =>
                {
                    b.Property<int>("TerminID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SalasalaID");

                    b.Property<int?>("predmetpredmetID");

                    b.Property<DateTime>("vrijemePocetka");

                    b.Property<DateTime>("vrijemeZavrsetka");

                    b.Key("TerminID");
                });

            builder.Entity("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Termin", b =>
                {
                    b.Reference("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Sala")
                        .InverseCollection()
                        .ForeignKey("SalasalaID");

                    b.Reference("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Predmet")
                        .InverseCollection()
                        .ForeignKey("predmetpredmetID");
                });

            builder.Entity("RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models.Ispit", b =>
            {
                b.Property<int>("IspitID")
                    .ValueGeneratedOnAdd();

                b.Property<int>("brojPrijavljenih");

                b.Property<DateTime>("vrijemeIspita");

                b.Key("IspitID");
            });

        }
    }
}
