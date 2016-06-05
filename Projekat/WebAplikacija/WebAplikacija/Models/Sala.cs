using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacija.Models
{
    public class Sala : Prostorija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int salaID { get; set; }
        public int kapacitet { get; set; }
        // public List<Termin> termini { get; set; }
        public Sala() : base("default") { }
        public Sala(string sala) : base(sala) {  }
        
        public Sala(int _id, string _naziv, int _kapacitet) : base(_naziv)
        {       
            salaID = _id;
            kapacitet = _kapacitet;
        }

    }
}
