using AplikacioniSloj.Servisi;
using Microsoft.AspNetCore.Mvc;
using PrezentacioniSloj.Models;
using SlojPodataka.Klase;

namespace PrezentacioniSloj.Controllers
{
    public class NalogController : BaseController
    {
        private readonly KorisnikServis _korisnikServis;

        public NalogController(KorisnikServis korisnikServis)
        {
            _korisnikServis = korisnikServis;
        }

        [HttpGet]
        public ActionResult Registracija()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Prijava()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registracija(RegistracijaModel model)
        {
            if (ModelState.IsValid)
            {
                bool uspesnaRegistracija;
                if (model.isAdmin)
                {
                    uspesnaRegistracija = _korisnikServis.DodajAdmina(new Korisnik
                    {
                        Jmbg = model.JMBG,
                        Ime = model.Ime,
                        Prezime = model.Prezime,
                        Drzavljanstvo = model.Drzavljanstvo,
                        Email = model.Email,
                        Lozinka = model.Lozinka,
                        IsAdmin = model.isAdmin
                    });
                }
                else
                {
                    uspesnaRegistracija = _korisnikServis.Dodaj(new Korisnik
                    {
                        Jmbg = model.JMBG,
                        Ime = model.Ime,
                        Prezime = model.Prezime,
                        Drzavljanstvo = model.Drzavljanstvo,
                        Email = model.Email,
                        Lozinka = model.Lozinka,
                        IsAdmin = model.isAdmin
                    });
                }

                if (uspesnaRegistracija)
                {
                    return RedirectToAction("Prijava");
                }
                else
                {
                    TempData["Poruka"] = "Greska prilikom registracije";
                    ModelState.AddModelError(string.Empty, "Регистрација није успешна. Молимо покушајте поново.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Prijava(PrijavaModel model)
        {
            if (ModelState.IsValid)
            {
                // Pozovite metodu iz servisa koja proverava korisničke podatke
                var prijavljeniKorisnik = _korisnikServis.PronadjiPoEmail(model.Email);

                if (prijavljeniKorisnik != null)
                {
                    // Ako je pronađen korisnik sa datom e-poštom, proverite lozinku
                    if (prijavljeniKorisnik.Lozinka == model.Lozinka)
                    {
                        // Lozinka je ispravna, postavite korisničke podatke u sesiju
                        HttpContext.Session.SetString("JMBG", prijavljeniKorisnik.Jmbg);
                        HttpContext.Session.SetString("Ime", prijavljeniKorisnik.Ime);
                        HttpContext.Session.SetString("Prezime", prijavljeniKorisnik.Prezime);
                        HttpContext.Session.SetString("Email", prijavljeniKorisnik.Email);
                        HttpContext.Session.SetString("Lozinka", prijavljeniKorisnik.Lozinka);
                        HttpContext.Session.SetString("Drzavljanstvo", prijavljeniKorisnik.Drzavljanstvo);
                        HttpContext.Session.SetInt32("IsAdmin", prijavljeniKorisnik.IsAdmin ? 1 : 0);

                        // Redirekcija na odgovarajući view u zavisnosti od tipa korisnika
                        if (prijavljeniKorisnik.IsAdmin)
                        {
                            return RedirectToAction("Pocetna", "Admin");
                        }
                        else 
                        {
                            return RedirectToAction("Pocetna", "Korisnik");
                        }
                    }
                    else
                    {
                        // Pogrešna lozinka
                        ModelState.AddModelError(string.Empty, "Погрешна лозинка");
                    }
                }
                else
                {
                    // Nema korisnika sa datom e-poštom
                    ModelState.AddModelError(string.Empty, "Нема корисника у бази података са тим имејлом!");
                }
            }

            // Ako ModelState nije validan, vraća se isti view sa postojećim podacima
            return View(model);
        }
    }
}
