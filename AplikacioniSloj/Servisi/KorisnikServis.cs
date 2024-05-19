using DomenskiSloj;
using SlojPodataka.Interfejsi;
using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacioniSloj.Servisi
{
    public class KorisnikServis
    {
        private IKorisnikRepo _korisnikRepo;
        private readonly PoslovnaPravila _poslovnaPravila;

        public KorisnikServis(IKorisnikRepo korisnikRepo, PoslovnaPravila poslovnaPravila)
        {
            _korisnikRepo = korisnikRepo;
            _poslovnaPravila = poslovnaPravila;
        }

        public DataSet DajSveKorisnike()
        {
            return _korisnikRepo.DajSveKorisnike();
        }

        public bool Dodaj(Korisnik objKorisnik)
        {
            return _korisnikRepo.NoviKorisnik(objKorisnik);
        }

        public bool DodajAdmina(Korisnik objKorisnik)
        {
            if (_poslovnaPravila.MogucnostDodavanjaAdmina())
            {
                return _korisnikRepo.DodajAdmina(objKorisnik);
            }
            
            return false;
        }

        public Korisnik PronadjiPoEmail(string email)
        {
            return _korisnikRepo.PronadjiPoEmail(email);
        }

        public bool Izmeni(string StariJMBG, Korisnik noviKorisnik)
        {
            return _korisnikRepo.IzmeniKorisnika(StariJMBG, noviKorisnik);
        }

        public bool Obrisi(string jmbg)
        {
            return _korisnikRepo.ObrisiKorisnika(jmbg);
        }
    }
}
