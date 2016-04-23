using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(RasporedIspitaPoSalamaDbContext context)
        {
            if (!context.Sale.Any())
            {
                context.Sale.AddRange(
                new Sala()
                {
                    naziv = "S-01",
                    kapacitet = 40,
                    brojPrijavljenih = 0,
                    trenutnaTemperatura = 25.0f,
                    termini = null,
                }
                );
                context.SaveChanges();
            }
        }
    }}
