using DomenskiSloj;
using SlojPodataka.Interfejsi;
using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacioniSloj.Servisi
{
    public class ZahtevServis
    {
        private readonly IZahtevRepo _zahtevRepo;
        private readonly PoslovnaPravila _poslovnaPravila;

        public ZahtevServis(IZahtevRepo zahtevRepo, PoslovnaPravila poslovnaPravila)
        {
            _zahtevRepo = zahtevRepo;
            _poslovnaPravila = poslovnaPravila;
        }

        public bool NoviZahtev(Zahtev zahtev)
        {
            if (_poslovnaPravila.VecKonkurisao(zahtev.JmbgKorisnika, zahtev.StipendijaId))
            {
                return false;
            }
            else
            {
                return _zahtevRepo.NoviZahtev(zahtev);
            }
        }

        public List<Zahtev> DajSveZahtevePoJmbgKorisnika(string jmbg)
        {
            return _zahtevRepo.DajSveZahtevePoJmbgKorisnika(jmbg);
        }

        public List<Zahtev> DajSveZahteve()
        {
            return _zahtevRepo.DajSveZahteve();
        }

        public List<Zahtev> DajSveZahteveBezStatusaNula()
        {
            return _zahtevRepo.DajSveZahteveBezStatusaNula();
        }

        public List<Zahtev> DajSveZahteveSaStatusomNula()
        {
            return _zahtevRepo.DajSveZahteveSaStatusomNula();
        }

        public bool PrihvatiZahtev(int zahtevId)
        {
            if (_poslovnaPravila.ProveraZahteva(zahtevId))
            {
                _zahtevRepo.PrihvatiZahtev(zahtevId);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void OdbijZahtev(int zahtevId)
        {
            _zahtevRepo.OdbijZahtev(zahtevId);
        }

        public Zahtev DobaviZahtevPoId(int zahtevId)
        {
            return _zahtevRepo.DobaviZahtevPoId(zahtevId);
        }

        public List<Zahtev> DajSveZahteveSaAkademskimUspehomVecimOd(double akademskiUspeh)
        {
           return _zahtevRepo.DajSveZahteveSaAkademskimUspehomVecimOd(akademskiUspeh);
        }

        public List<Zahtev> DajSveZahteveSaAkademskimUspehomVecimIliJednakim(double akademskiUspeh)
        {
            return _zahtevRepo.DajSveZahteveSaAkademskimUspehomVecimIliJednakim(akademskiUspeh);
        }


    }
}
