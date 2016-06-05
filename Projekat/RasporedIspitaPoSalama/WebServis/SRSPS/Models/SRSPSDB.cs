using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebServis.Models;

namespace WebServis.SRSPS.Models
{
    public class SRSPSDB:DbContext
    {
        public SRSPSDB()
        {
            Database.SetInitializer<SRSPSDB>(null);
        }
        DbSet<Ispit> Ispiti;
        DbSet<Sala> Sale;
        DbSet<Predmet> Predmeti;
        DbSet<Termin> Termini;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebServis.Models.Sala> Salas { get; set; }

        public System.Data.Entity.DbSet<WebServis.Models.Ispit> Ispits { get; set; }

        public System.Data.Entity.DbSet<WebServis.Models.Predmet> Predmets { get; set; }

        public System.Data.Entity.DbSet<WebServis.Models.Termin> Termins { get; set; }
    }
}