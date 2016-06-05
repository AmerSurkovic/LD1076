using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacija.Models
{
    public abstract class Osoba
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }

        public Osoba(string _ime, string _prezime, DateTime _datumRodjenja)
        {
            ime = _ime;
            prezime = _prezime;
            datumRodjenja = _datumRodjenja;
        }

        public override string ToString()
        {
            return ime + " " + prezime;
        }

    }
}
