using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacija.Models
{
    public class Predmet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int predmetID { get; set; }
        public string naziv { get; set; }
        public int godina { get; set; }
        public int semestar { get; set; }
        public float ects { get; set; }
        public int brojUpisanihStudenata { get; set; }

        public Predmet(int _predmetID, string _naziv, int _godina, int _semestar, float _ects, int _brojUpisanih)
        {
            predmetID = _predmetID;
            naziv = _naziv;
            godina = _godina;
            semestar = _semestar;
            ects = _ects;
            brojUpisanihStudenata = _brojUpisanih;
        }

        public Predmet()
        {
        }

        public override string ToString()
        {
            return naziv;
        }
    }
}
