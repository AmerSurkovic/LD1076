#### Tema: Raspored ispita u salama i laboratorijama
**Članovi tima:**
1. Vedad Mulić
2. Edin Begić
3. Amer Šurković


## Opis teme

Sistem se razvija da bi olakšao organizaciju kako pismenih ispita na nekom fakultetu tako i svih ostalih aktivnosti koje se mogu modelirati kao ovaj vid testiranja.
Korisnici sistema su i studenti i sami djelatnici ustanove koja sprovodi testiranje.
Cilj je da se studentima/učenicima obezbjedi pregled detalja vezanih za ispitni rok koji su od znacaja za same studente. Sa druge strane, djelatnici ustanove koji su zaduženi za organizaciju ispitnog roka (testiranja) imaju mogučnost da uz pomoć ove aplikacije pronađu zadovoljavajući vremenski raspored ispita i raspored studenata po salama u kojim se održava ispit/testiranje. Takođe, djelatnici ustanove (npr. studentska služba fakulteta) imaju mogućnost da u slučaju eventualnih promjena obavještavaju i studente i ostalo osoblje fakulteta o istim.


## Procesi

Djelatnik ustanove unosi podatke o ispitu (maksimalan broj učesnika koji mogu izaći na ispit/testiranje, način rasporeda studenata, željeni datum i vrijeme održavanja  itd.). Sistem onda na osnovu raspoloživih informacija daje optimalnu raspodjelu studenata ukoliko je to uopšte moguće, dok u suprotnom predlaže nekoliko alternativnih mogučnosti (drugi datum ili druga satnica). Kada djelatnik nađe zadovoljavajući termin i raspored podaci se spašavaju i svi korisnici sistema imaju mogućnost da vide ove izmjene (internet).

Jedna od mogućih izmjena koje djelatnik ustanove može da obavi jeste otkazivanje ispita koji je već prijavljen u sistemu.

Administrator ima opciju prijave pomoću svog unaprijed dodijeljenog username-a i passworda ili pomoću koda svoje magnetne kartice koja
je skenirana pomoću RFID uređaja. Administratorska prijava će biti uspješna ukoliko je kod skenirane kartice iz liste kodova koji su 
spašeni u bazu.

Svi korisnici imaju opciju pregleda vremenske prognoze za taj dan, pri čemu sistem pomoću GPS-a na korisničkom uređaju (ukoliko takav postoji) određuje tačnu lokaciju za prikaz. Ovaj eksterni servis je posebno namijenjen za Windows Phone uređaje, na kojim se to lagano
može istestirati. 

Administratori također imaju opciju izvršenja CRUD operacija nad svim važnijim pojmovima ovog sistema, koristeći ASP.NET aplikaciju. Pokretanje istog se može izvršiti kroz poziv 'WebAplikacija'. 

## Funkcionalnosti

- Mogućnost organizacije ispita
- Mogućnost otkazivanja ispita
- Mogućnost unosa novih sala u sistem te ažuriranje stanja svih sala
- Dodjeljivanje prioriteta predmetima, semestrima, godinama studija i slično
- Prijava administratora skeniranjem njegove magnetne kartice koristeći RFID uređaj
- Pregled vrememenske prognoze za taj dan za lokaciju koja je određena GPS-om na korisničkom uređaju (laptop/mobitel)
- Administratorski pristup svim važnijim operacijama kroz ASP.NET MVC aplikaciju

## Akteri

Akteri datog sistema su:
 - Studenti:
   Studenti imaju pristup informaciji o tome koje ispite polažu te u kojim salama se ti ispiti odvijaju.
 - Administrativno osoblje (npr. studentska služba)
   Administrator sistema ima mogućnost registracije ispita te postavljanja restrikcija na same ispite.
   

## Final Info

- Koristili smo SqlLite 7.0 LOCAL bazu za pohranjivanje naših podataka 
- Korišten je RFID uređaj za prijavu administratora, kod se nalazi u klasi 'Prijava administratora.xaml.cs'
- Validacija je ispoštovana kod prijave administratora 
- Koristi se OpenWeatherMap eksterni servis,a klasa u kojoj se poziva api jeste 'VremenskaPrognozaProxy.cs'
- Implementirano je korištenje GPS-a uređaja i to u klasi 'LocationManager.cs', te se prikaz teksta u svim klasama 'wrap'-a kako bi se prilagodilo Windows Phone-u
- WebServis se pruža za administratora i to mogućnost CRUD opercija za Sale, Predmete, Ispite. Nalazi se u posebnoj ASP.NET MVC aplikaciji 'WebAplikacija'
