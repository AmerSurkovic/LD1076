using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.RasporedIspitaPoSalamaBaza.Models
{
    public class Predmet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int predmetID { get; set; }
        public string naziv { get; set; }
        public int godina { get; set; }
        public int semestar { get; set; }
        public int ects { get; set; }
        public int brojUpisanihStudenata { get; set; }
      

    }
}
