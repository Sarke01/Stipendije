using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Interfejsi
{
    public interface IZahtevRepo
    {
        List<Zahtev> DajSveZahtevePoJmbgKorisnika(string jmbg);
        bool NoviZahtev(Zahtev objNoviZahtev);
        List<Zahtev> DajSveZahteve();
        List<Zahtev> DajSveZahteveBezStatusaNula();
        List<Zahtev> DajSveZahteveSaStatusomNula();
        void PrihvatiZahtev(int zahtevId);
        void OdbijZahtev(int zahtevId);
        Zahtev DobaviZahtevPoId(int zahtevId);
        Zahtev DobaviZahtevPoJmbgKorisnikaIStipendijaId(string jmbg, int stipendijaId);
        List<Zahtev> DajSveZahteveSaAkademskimUspehomVecimOd(double akademskiUspeh);
        List<Zahtev> DajSveZahteveSaAkademskimUspehomVecimIliJednakim(double minimalniAkademskiUspeh);

    }
}
