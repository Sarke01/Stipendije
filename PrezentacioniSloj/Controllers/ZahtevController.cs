using AplikacioniSloj.Servisi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrezentacioniSloj.Models;
using SlojPodataka.Klase;
using System.Reflection;
using System.Text.Json;

namespace PrezentacioniSloj.Controllers
{
    public class ZahtevController : BaseController
    {

        private readonly ZahtevServis _zahtevServis;

        public ZahtevController(ZahtevServis zahtevServis)
        {
            _zahtevServis = zahtevServis;
        }

        public IActionResult Konkurisi(int stipendijaId)
        {
            return View(stipendijaId);
        }

        public IActionResult Kreiraj(int stipendijaId, ZahtevModel zahtevModel)
        {
            var jmbg = HttpContext.Session.GetString("JMBG");
            zahtevModel.FinansijskaPotreba = Request.Form["FinansijskaPotreba"] == "on";
            zahtevModel.DrustvenoAngazovanje = Request.Form["DrustvenoAngazovanje"] == "on";
            Zahtev zahtev = new Zahtev
            {
                JmbgKorisnika = jmbg,
                StipendijaId = zahtevModel.StipendijaId,
                Razlozi = zahtevModel.Razlozi,
                FinansijskaPotreba = zahtevModel.FinansijskaPotreba,
                DrustvenoAngazovanje = zahtevModel.DrustvenoAngazovanje,
                AkademskiUspeh = zahtevModel.AkademskiUspeh,
                Status = "0"
            };

            var uspeh = _zahtevServis.NoviZahtev(zahtev);

            if (uspeh)
            {
                TempData["Poruka"] = "Uspesno ste podneli zahtev.";
            }
            else
            {
                TempData["Poruka"] = "Kandidat je vec konkurisao za ovu stipendiju.";
            }

            return RedirectToAction("Pocetna", "Korisnik");
        }

        public IActionResult Stampa(int zahtevId)
        {
            Zahtev zahtev = _zahtevServis.DobaviZahtevPoId(zahtevId);
            return View(zahtev);
        }

        public IActionResult StampaSaFilterom(double akademskiUspeh)
        {
            List<Zahtev> zahtevi = _zahtevServis.DajSveZahteveSaAkademskimUspehomVecimIliJednakim(akademskiUspeh);
            return View(zahtevi);
        }
    }
}
