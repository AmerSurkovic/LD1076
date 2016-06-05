using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    public class Student : Osoba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentID { get; set; }
        public int brojIndeksa { get; set; }
        public Student(): base("","",DateTime.Now) {  }
        public Student(string _ime, string _prezime, DateTime _datumRodjenja) : base(_ime, _prezime, _datumRodjenja) { }
        public Student(string _ime, string _prezime, DateTime _datumRodjenja, int _brIndeksa) : base(_ime, _prezime, _datumRodjenja)
        {
            brojIndeksa = _brIndeksa;
        }
    }
}
