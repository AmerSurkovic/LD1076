using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplikacija.Models
{
    public abstract class Prostorija
    {
        public string naziv { get; set; }

        public Prostorija(string _naziv)
        {
            naziv = _naziv;
        }
    }
}
