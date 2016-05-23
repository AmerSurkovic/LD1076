using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System.IO;
using Windows.Storage;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    class RasporedIspitaPoSalamaDbContext : DbContext
    {
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Termin> Termini { get; set; }
        public DbSet<Ispit> Ispiti { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "RasporedIspitaPoSalama.db";
            try
            {
                //za tačnu putanju gdje se nalazi baza uraditi ovdje debug i procitati Path
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
               databaseFilePath);
            }
            catch (InvalidOperationException) { }
            //Sqlite baza
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }

    }
}
