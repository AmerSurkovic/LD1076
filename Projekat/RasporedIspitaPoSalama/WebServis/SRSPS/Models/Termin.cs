using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServis.Models
{
    public class Termin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TerminID { get; set; }
        public DateTime vrijemePocetka { get; set; }
        public DateTime vrijemeZavrsetka { get; set; }

        public Termin(int _id, DateTime vrijemePocetak, DateTime vrijemeZavrsetak)
        {
            TerminID = _id;
            vrijemePocetka = vrijemePocetak;
            vrijemeZavrsetka = vrijemeZavrsetak;
        }
        public Termin()
        {
            vrijemePocetka = DateTime.Now;
            vrijemeZavrsetka = DateTime.Now;
        }
    }
}
