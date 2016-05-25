using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    public class Ispit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ispitID { get; set; }
        public int brojPrijavljenih { get; set; }
        public DateTime vrijemeIspita { get; set; }
    }
}
