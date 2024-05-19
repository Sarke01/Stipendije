using AplikacioniSloj.Servisi;
using Microsoft.AspNetCore.Mvc;

namespace PrezentacioniSloj.Controllers
{
    public class HomeController : BaseController
    {

        private readonly KorisnikServis _korisnikServis;

        public HomeController(KorisnikServis korisnikServis)
        {
            _korisnikServis = korisnikServis;
        }

        public IActionResult Pocetna()
        {           
            return View();
        }

        public IActionResult PrijavaIliRegistracija()
        {
            return View();
        }

        public IActionResult OServisu()
        {
            return View();
        }
    }
}
