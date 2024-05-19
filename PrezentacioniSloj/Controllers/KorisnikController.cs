using AplikacioniSloj.Servisi;
using Microsoft.AspNetCore.Mvc;
using PrezentacioniSloj.Models;
using SlojPodataka.Klase;
using System.Data;

namespace PrezentacioniSloj.Controllers
{
    public class KorisnikController : BaseController
    {
        private readonly KorisnikServis _korisnikServis;
        private readonly StipendijaServis _stipendijaServis;
        private readonly ZahtevServis _zahtevServis;

        public KorisnikController(KorisnikServis korisnikServis, StipendijaServis stipendijaServis, ZahtevServis zahtevServis)
        {
            _korisnikServis = korisnikServis;
            _stipendijaServis = stipendijaServis;
            _zahtevServis = zahtevServis;
        }

        public IActionResult Pocetna()
        {
            var jmbg = HttpContext.Session.GetString("JMBG");
            List<Stipendija> stipendije = _stipendijaServis.DajSveStipendije();
            List<Zahtev> zahteviKorisnika = _zahtevServis.DajSveZahtevePoJmbgKorisnika(jmbg);
            return View(new KorisnikPocetnaViewModel { Stipendije = stipendije, Zahtevi = zahteviKorisnika });
        }

        [HttpPost]
        public IActionResult Profil(Korisnik korisnik)
        {
            
            return View(korisnik);
        }

        [HttpPost]
        public IActionResult IzmeniPodatke(RegistracijaModel model, string action)
        {

            if (action == "izmeni")
            {
                // Dobavi JMBG korisnika iz sesije
                var jmbgIzSesije = HttpContext.Session.GetString("JMBG");

                if (!string.IsNullOrEmpty(jmbgIzSesije))
                {
                    Korisnik korisnik = new Korisnik();
                    korisnik.Jmbg = model.JMBG;
                    korisnik.Ime = model.Ime;
                    korisnik.Prezime = model.Prezime;
                    korisnik.Email = model.Email;
                    korisnik.Lozinka = model.Lozinka;
                    korisnik.Drzavljanstvo = model.Drzavljanstvo;

                    if (_korisnikServis.Izmeni(jmbgIzSesije, korisnik))
                        return RedirectToAction("Pocetna", "Home");
                }
                return View();

            }

            else if (action == "obrisi")
            {
                var jmbg = HttpContext.Session.GetString("JMBG");

                if (!string.IsNullOrEmpty(jmbg))
                {
                    if (_korisnikServis.Obrisi(jmbg))
                        return RedirectToAction("Pocetna", "Home");
                    return View();
                }
                return View();
            }
            return View();
        }

    }
}
