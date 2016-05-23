using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models
{
    public class Sala : Prostorija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int salaID { get; set; }
        public int kapacitet { get; set; }
        public float trenutnaTemperatura { get; set; }
        public List<Termin> termini { get; set; }
        public int brojPrijavljenih { get; set; }
    }
}
