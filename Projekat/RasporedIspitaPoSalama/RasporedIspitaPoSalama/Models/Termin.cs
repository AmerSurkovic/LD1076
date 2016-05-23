using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models
{
    public class Termin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TerminID { get; set; }
        public DateTime vrijemePocetka { get; set; }
        public DateTime vrijemeZavrsetka { get; set; }
        public Predmet predmet { get; set; }

        public Termin(DateTime vrijemePocetak, DateTime vrijemeZavrsetak, Predmet pred)
        {
            vrijemePocetka = vrijemePocetak;
            vrijemeZavrsetka = vrijemeZavrsetak;
            predmet = pred;
        }
    }
}
