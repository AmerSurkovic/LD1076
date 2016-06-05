using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    public class RasporedUSali
    {
        public int id { get; set; }
        public Sala sala { get; set; }
        public int brojSlobodnihMjesta { get; set; }
        public bool[,] raspored;

        public RasporedUSali(int _id, Sala _sala, int _brojSlobodnihMjesta, bool[,] _raspored)
        {
            id = _id;
            sala = _sala;
            brojSlobodnihMjesta = _brojSlobodnihMjesta;
            raspored = _raspored;
        }

        public override string ToString()
        {
            return sala.naziv;
        }
    }
}
