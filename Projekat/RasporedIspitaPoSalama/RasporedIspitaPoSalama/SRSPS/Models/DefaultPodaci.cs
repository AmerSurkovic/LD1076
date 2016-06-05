using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    class DefaultPodaci
    {
        public static void Initialize(RasporedIspitaPoSalamaDbContext context)
        {
            try
            {
                if (!context.Sale.Any())
                {
                    context.Sale.AddRange(
                    new Sala("S1")
                    {
                        salaID = 1,
                        kapacitet = 80

                    },
                    new Sala("S2")
                    {
                        salaID = 2,
                        kapacitet = 80

                    }, new Sala("S3")
                    {
                        salaID = 3,
                        kapacitet = 80

                    }, new Sala("S4")
                    {
                        salaID = 4,
                        kapacitet = 80

                    }, new Sala("VA")
                    {
                        salaID = 5,
                        kapacitet = 80

                    }, new Sala("MA")
                    {
                        salaID = 6,
                        kapacitet = 80

                    }
                    );
                    context.SaveChanges();
                }
                if (!context.Predmeti.Any())
                {
                    context.Predmeti.AddRange(
                    new Predmet()
                    {
                        predmetID = 1,
                        naziv = "Inženjerska matematika 2",
                        ects = 6,
                        brojUpisanihStudenata = 1000,
                        godina = 1,
                        semestar = 2

                    },
                     new Predmet()
                     {
                         predmetID = 2,
                         naziv = "Električni krugovi",
                         ects = 6,
                         brojUpisanihStudenata = 500,
                         godina = 1,
                         semestar = 2

                     }, 
                     new Predmet()
                     {
                         predmetID = 3,
                         naziv = "Elektronicki elementi i sklopovi",
                         ects = 6,
                         brojUpisanihStudenata = 10000,
                         godina = 1,
                         semestar = 2

                     }, 
                     new Predmet()
                     {
                         predmetID = 4,
                         naziv = "Tehnike programiranja",
                         ects = 6,
                         brojUpisanihStudenata = 10000,
                         godina = 1,
                         semestar = 2

                     }
                    );

                    context.SaveChanges();
                }
                if (!context.Studenti.Any())
                {
                    context.Studenti.AddRange(
                        new Student()
                        {
                            studentID = 1,
                            ime = "Edin",
                            prezime = "Begic",
                            datumRodjenja = DateTime.ParseExact("11/05/1995", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            brojIndeksa=16701
                        },
                         new Student()
                         {
                             studentID = 2,
                             ime = "Amer",
                             prezime = "Surkovic",
                             datumRodjenja = DateTime.ParseExact("11/05/1995", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                             brojIndeksa = 16781
                         },
                          new Student()
                          {
                              studentID = 3,
                              ime = "Vedad",
                              prezime = "Mulic",
                              datumRodjenja = DateTime.ParseExact("11/05/1995", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                              brojIndeksa = 16687
                          }
                    );
                }
            }
            catch(ArgumentNullException e)
            {
                
                string s=e.Source.ToString();
            }
            
        }
    }
}
