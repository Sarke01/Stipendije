using AplikacioniSloj.Servisi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SlojPodataka.Klase;

namespace PrezentacioniSloj.Controllers
{
    public class BaseController : Controller
    {       
        public override void OnActionExecuting(ActionExecutingContext context)
        {           
            var korisnik = new Korisnik
            {
                Jmbg = HttpContext.Session.GetString("JMBG"),
                Ime = HttpContext.Session.GetString("Ime"),
                Prezime = HttpContext.Session.GetString("Prezime"),
                Email = HttpContext.Session.GetString("Email"),
                Lozinka = HttpContext.Session.GetString("Lozinka"),
                Drzavljanstvo = HttpContext.Session.GetString("Drzavljanstvo"),
                IsAdmin = HttpContext.Session.GetInt32("IsAdmin") == 1 ? true : false
            };


            ViewData["Korisnik"] = korisnik;

            base.OnActionExecuting(context);
        }
    }
}
