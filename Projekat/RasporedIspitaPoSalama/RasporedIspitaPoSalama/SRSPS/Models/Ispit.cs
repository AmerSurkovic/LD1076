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
        public Termin termin { get; set; }
        public Predmet predmet { get; set; }
        public List<RasporedUSali> rasporedi {get; set;}

        public Ispit()
        {
           
        }
        
        public Ispit(int _id, int _brojPrijavljenih, Termin _termin, Predmet _predmet, List<RasporedUSali> _rus)
        {
            ispitID = _id;
            brojPrijavljenih = _brojPrijavljenih;
            termin = _termin;
            predmet = _predmet;
            rasporedi = _rus;
        }

        public override string ToString()
        {
            return predmet.ToString();
        }
    }
}
