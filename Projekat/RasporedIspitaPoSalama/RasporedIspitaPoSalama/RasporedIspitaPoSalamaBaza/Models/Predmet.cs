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

    }
}
