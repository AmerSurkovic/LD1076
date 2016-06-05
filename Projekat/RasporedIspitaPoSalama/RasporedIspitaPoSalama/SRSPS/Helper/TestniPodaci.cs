using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<Models.Sala> sale = new ObservableCollection<Models.Sala>()
            {
                new Models.Sala(1,"VA",80),
                new Models.Sala(2,"MA",80),
                new Models.Sala(3,"S0",80),
                new Models.Sala(4,"S1",80),
                new Models.Sala(5,"S2",80),
                new Models.Sala(6,"S8",80)

            };

        public List<Models.RasporedUSali> rus;

        public TestniPodaci()
        {
            ispitniRok = new Models.IspitniRok();
            ucitajPodatke();
        }

        private void ucitajPodatke()
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
          //      ispitniRok.saleNaRaspolaganju = sale;
            
            }

        public static ObservableCollection<Models.IspitniRok> dajIspitneRokove()
        {
            ObservableCollection<Models.Sala> saleIzBaze=new ObservableCollection<Models.Sala>();
            List<Models.Predmet> predmetiIzBaze = new List<Models.Predmet>();
            using (var db = new Models.RasporedIspitaPoSalamaDbContext())
            {
                foreach(Models.Sala s in db.Sale)
                    saleIzBaze.Add(s);
                foreach (Models.Predmet p in db.Predmeti)
                    predmetiIzBaze.Add(p);
            }

            ObservableCollection<Models.IspitniRok> IR_lista = new ObservableCollection<Models.IspitniRok>();

            Models.IspitniRok ir1 = new Models.IspitniRok();
            Models.IspitniRok ir2 = new Models.IspitniRok();
            Models.IspitniRok ir3 = new Models.IspitniRok();

            var predmeti = new List<Models.Predmet>()
                {
                    new Models.Predmet(1,"Razvoj mobilnih aplikacija",2,2,5,120),
                    new Models.Predmet(2,"Automati i formalni jezici",2,2,6,80),
                    new Models.Predmet(3,"Ugradbeni sistemi",2,2,5,100),
                    new Models.Predmet(4,"Osnove racunarskih mreza",2,2,5,133),
                    new Models.Predmet(5,"Racunarske arhitekture",2,2,6,135),
                    new Models.Predmet(6,"Osnove racunarstva",2,2,6,135),
                    new Models.Predmet(7,"Inzenjerska matematika 1",2,2,6,135),
                    new Models.Predmet(8,"Linearna algebra i geometrija",2,2,6,135),
                    new Models.Predmet(9,"Osnove elektrotehnike",2,2,6,135),
                    new Models.Predmet(10,"Inzenjerska fizika 1",2,2,6,135)
                };

            string format = "dd/MM/yyyy HH:mm";
            CultureInfo provider = CultureInfo.InvariantCulture;

            var  termini = new List<Models.Termin>()
                {
                    new Models.Termin(1,DateTime.ParseExact("06/06/2016 09:00",format,provider),DateTime.ParseExact("06/06/2016 11:00",format,provider)),
                    new Models.Termin(2,DateTime.ParseExact("06/06/2016 12:00",format,provider),DateTime.ParseExact("06/06/2016 13:30",format,provider))
                   /* new Models.Termin(2,Convert.ToDateTime("06.06.2016 12:00"),Convert.ToDateTime("06.06.2016 13:30")),
                    new Models.Termin(3,Convert.ToDateTime("10.06.2016 09:00"),Convert.ToDateTime("10.06.2016 11:00")),
                    new Models.Termin(4,Convert.ToDateTime("15.06.2016 13:00"),Convert.ToDateTime("15.06.2016 15:00")),
                    new Models.Termin(5,Convert.ToDateTime("17.06.2016 09:00"),Convert.ToDateTime("17.06.2016 10:30")),
                    new Models.Termin(6,Convert.ToDateTime("18.06.2016 11:00"),Convert.ToDateTime("06.06.2016 12:30"))*/
            
                };

            bool[,] mraspored = new bool[8, 10];
            for(int i=0;i<8;i++)
                for(int j=0;j<10;j++)
                {
                    if (i % 2 == 0 && j % 3 == 0 || j == 0 && i % 2 == 1 || i == 7 & j % 3 == 1)
                        mraspored[i, j] = true;
                    else
                        mraspored[i, j] = false;
                }
            var rus = new List<Models.RasporedUSali>()
                {
                    new Models.RasporedUSali(1,saleIzBaze[0],20,mraspored),
                    new Models.RasporedUSali(2,saleIzBaze[1],15,mraspored),
                    new Models.RasporedUSali(3,saleIzBaze[2],30,mraspored),
                    new Models.RasporedUSali(4,saleIzBaze[3],25,mraspored),
                    new Models.RasporedUSali(5,saleIzBaze[4],10,mraspored),
                    //new Models.RasporedUSali(6,saleIzBaze[5],35,mraspored)
                 };
            ir1.imeRoka="SEPTEMBAR";
            ir1.datumPocetka = Convert.ToDateTime("01.09.2016.");
            ir1.datumKraja = Convert.ToDateTime("01.10.2016.");
            ir1.ispiti = new System.Collections.ObjectModel.ObservableCollection<Models.Ispit>();
            ir1.ispiti.Add(new Models.Ispit(1, 100, termini[0], predmeti[0], rus));
            ir1.ispiti.Add(new Models.Ispit(2, 100, termini[1], predmeti[1], rus));
            ir1.ispiti.Add(new Models.Ispit(3, 100, termini[0], predmeti[2], rus));
            ir1.ispiti.Add(new Models.Ispit(4, 100, termini[1], predmeti[3], rus));
            ir1.ispiti.Add(new Models.Ispit(5, 100, termini[0], predmeti[4], rus));
            //      ispitniRok.saleNaRaspolaganju = sale;

            IR_lista.Add(ir1);

            ir2.imeRoka = "JUNI";
            ir2.datumPocetka = Convert.ToDateTime("06.06.2016.");
            ir2.datumKraja = Convert.ToDateTime("10.07.2016.");
            ir2.ispiti = new System.Collections.ObjectModel.ObservableCollection<Models.Ispit>();
            ir2.ispiti.Add(new Models.Ispit(1, 100, termini[0], predmetiIzBaze[0], rus));
            ir2.ispiti.Add(new Models.Ispit(2, 100, termini[1], predmetiIzBaze[1], rus));
            ir2.ispiti.Add(new Models.Ispit(3, 100, termini[0], predmetiIzBaze[2], rus));
            ir2.ispiti.Add(new Models.Ispit(4, 100, termini[1], predmetiIzBaze[3], rus));
        
            IR_lista.Add(ir2);

           

            ir3.imeRoka = "JANUAR";
            ir3.datumPocetka = Convert.ToDateTime("10.01.2016.");
            ir3.datumKraja = Convert.ToDateTime("01.02.2016.");
            ir3.ispiti = new System.Collections.ObjectModel.ObservableCollection<Models.Ispit>();
            ir3.ispiti.Add(new Models.Ispit(1, 100, termini[0], predmeti[0], rus));
            ir3.ispiti.Add(new Models.Ispit(2, 100, termini[1], predmeti[6], rus));
            ir3.ispiti.Add(new Models.Ispit(3, 100, termini[0], predmeti[1], rus));
            ir3.ispiti.Add(new Models.Ispit(4, 100, termini[1], predmeti[7], rus));
            ir3.ispiti.Add(new Models.Ispit(5, 100, termini[0], predmeti[3], rus));
            //      ispitniRok.saleNaRaspolaganju = sale;
            IR_lista.Add(ir3);

            return IR_lista;

        }
    }
}
