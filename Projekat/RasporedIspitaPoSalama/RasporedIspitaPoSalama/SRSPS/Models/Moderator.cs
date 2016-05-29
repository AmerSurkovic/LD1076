using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    class Moderator : Osoba
    {
        public Predmet predmet { get; set; }
        public string token { get; set; }
        public Moderator(string _ime, string _prezime,DateTime _datumRodjenja) : base(_ime, _prezime, _datumRodjenja) { }
    }
}
