using AplikacioniSloj.Servisi;
using Microsoft.AspNetCore.Mvc;

namespace PrezentacioniSloj.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ZahtevServis _zahtevServis;

        public AdminController(ZahtevServis zahtevServis)
        {
            _zahtevServis = zahtevServis;
        }

        public IActionResult Pocetna()
        {
            var zahtevi = _zahtevServis.DajSveZahteveSaStatusomNula();
            return View(zahtevi);
        }

        public IActionResult PrihvatiZahtev(int zahtevId)
        {
            var uspeh = _zahtevServis.PrihvatiZahtev(zahtevId);
            if (uspeh)
            {
                TempData["Poruka"] = "Zahtev je uspešno prihvaćen.";
            }
            else
            {
                TempData["Poruka"] = "Kandidat ne ispunjava sve uslove za ovu stipendiju.";
            }

            return RedirectToAction("Pocetna");
        }

        public IActionResult OdbijZahtev(int zahtevId)
        {
            _zahtevServis.OdbijZahtev(zahtevId);
            return RedirectToAction("Pocetna");
        }

        public IActionResult FiltrirajZahteve(double akademskiUspeh)
        {
           var zahtevi = _zahtevServis.DajSveZahteveSaAkademskimUspehomVecimOd(akademskiUspeh);
            return View("Pocetna", zahtevi);
        }
    }
}
