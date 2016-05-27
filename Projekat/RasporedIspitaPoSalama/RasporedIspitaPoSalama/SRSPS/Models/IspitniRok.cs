using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    public class IspitniRok 
    {
        public DateTime datumPocetka { get; set; }
        public DateTime datumKraja { get; set; }
        public List<Sala> saleNaRaspolaganju { get; set; }
        public ObservableCollection<Ispit> ispiti { get; set; }

        public IspitniRok()
        {
            saleNaRaspolaganju = new List<Sala>();
            ispiti = new ObservableCollection<Ispit>();
        }
    }
}
