using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Helper
{
    public class TestniPodaci
    {
        public Models.IspitniRok ispitniRok;
        public List<Models.Predmet> predmeti;
        public List<Models.Termin> termini;
        public List<Models.Sala> sale;
        public List<Models.RasporedUSali> rus;

        public TestniPodaci()
        {
            ispitniRok = new Models.IspitniRok();
            ucitajPodatke();
        }

        public void ucitajPodatke()
        {

            predmeti = new List<Models.Predmet>()
                {
                    new Models.Predmet(1,"Razvoj mobilnih aplikacija",2,2,5,120),
                    new Models.Predmet(2,"Automati i formalni jezici",2,2,6,80),
                    new Models.Predmet(3,"Ugradbeni sistemi",2,2,5,100),
                    new Models.Predmet(4,"Osnove racunarskih mreza",2,2,5,133),
                    new Models.Predmet(5,"Racunarske arhitekture",2,2,6,135)
                };
            string format = "dd/MM/yyyy HH:mm";
            CultureInfo provider = CultureInfo.InvariantCulture;

            termini = new List<Models.Termin>()
                {
                    new Models.Termin(1,DateTime.ParseExact("06/06/2016 09:00",format,provider),DateTime.ParseExact("06/06/2016 11:00",format,provider)),
                    new Models.Termin(2,DateTime.ParseExact("06/06/2016 12:00",format,provider),DateTime.ParseExact("06/06/2016 13:30",format,provider))
                   /* new Models.Termin(2,Convert.ToDateTime("06.06.2016 12:00"),Convert.ToDateTime("06.06.2016 13:30")),
                    new Models.Termin(3,Convert.ToDateTime("10.06.2016 09:00"),Convert.ToDateTime("10.06.2016 11:00")),
                    new Models.Termin(4,Convert.ToDateTime("15.06.2016 13:00"),Convert.ToDateTime("15.06.2016 15:00")),
                    new Models.Termin(5,Convert.ToDateTime("17.06.2016 09:00"),Convert.ToDateTime("17.06.2016 10:30")),
                    new Models.Termin(6,Convert.ToDateTime("18.06.2016 11:00"),Convert.ToDateTime("06.06.2016 12:30"))*/
            
                };


            sale = new List<Models.Sala>()
            {
                new Models.Sala(1,"VA",250),
                new Models.Sala(2,"MA",120),
                new Models.Sala(3,"S0",80),
                new Models.Sala(4,"S1",75),
                new Models.Sala(5,"S2",50),
                new Models.Sala(6,"Citaona",60)
           
            };


            rus = new List<Models.RasporedUSali>()
                {
                    new Models.RasporedUSali(1,sale[0],20,new bool[10, 10]),
                    new Models.RasporedUSali(2,sale[1],15,new bool[10, 10]),
                    new Models.RasporedUSali(3,sale[2],30,new bool[10, 10]),
                    new Models.RasporedUSali(4,sale[3],25,new bool[10, 10]),
                    new Models.RasporedUSali(5,sale[4],10,new bool[10, 10]),
                    new Models.RasporedUSali(6,sale[5],35,new bool[10, 10])
                 };
                ispitniRok.datumPocetka = Convert.ToDateTime("06.06.2016.");
                ispitniRok.datumKraja = Convert.ToDateTime("10.07.2016.");
                ispitniRok.ispiti = new System.Collections.ObjectModel.ObservableCollection<Models.Ispit>();
                ispitniRok.ispiti.Add(new Models.Ispit(1, 100, termini[0], predmeti[0],rus));
                ispitniRok.ispiti.Add(new Models.Ispit(2, 100, termini[1], predmeti[1],rus));
                ispitniRok.ispiti.Add(new Models.Ispit(3, 100, termini[0], predmeti[2],rus));
                ispitniRok.ispiti.Add(new Models.Ispit(4, 100, termini[1], predmeti[3],rus));
                ispitniRok.ispiti.Add(new Models.Ispit(5, 100, termini[0], predmeti[4],rus));
                ispitniRok.saleNaRaspolaganju = sale;
            
            }
    }
}
