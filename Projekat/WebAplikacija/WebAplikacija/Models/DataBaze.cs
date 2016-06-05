using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class DataBaze:DbContext
    {
        public DataBaze()
        {
            Database.SetInitializer<DataBaze>(null);

        }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Ispit>Ispiti { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        //za onemogucavanje automatskog dodavanja mnozine
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}