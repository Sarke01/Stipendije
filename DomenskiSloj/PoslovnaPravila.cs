using SlojPodataka.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomenskiSloj
{
    public class PoslovnaPravila
    {
        private readonly IZahtevRepo _zahtevRepo;
        private readonly IStipendijaRepo _stipendijaRepo;
        private readonly IKorisnikRepo _korisnikRepo;

        public PoslovnaPravila(IZahtevRepo zahtevRepo, IStipendijaRepo stipendijaRepo, IKorisnikRepo korisnikRepo)
        {
            _zahtevRepo = zahtevRepo;
            _stipendijaRepo = stipendijaRepo;
            _korisnikRepo = korisnikRepo;
        }

        public bool ProveraZahteva(int zahtevId)
        {
            var zahtev = _zahtevRepo.DobaviZahtevPoId(zahtevId);
            var stipendija = _stipendijaRepo.DobaviStipendijuPoId(zahtev.StipendijaId);
            var kriterijum = stipendija.Kriterijum;

            bool ispunjavaKriterijume = true;

            if (kriterijum.FinansijskaPotreba && !zahtev.FinansijskaPotreba)
            {
                ispunjavaKriterijume = false;
            }

            if (kriterijum.DrustvenoAngazovanje && !zahtev.DrustvenoAngazovanje)
            {
                ispunjavaKriterijume = false;
            }

            if (kriterijum.AkademskiUspeh > zahtev.AkademskiUspeh)
            {
                ispunjavaKriterijume = false;
            }

            return ispunjavaKriterijume;
        }

        public bool VecKonkurisao(string jmbg, int stipendijaId)
        {
            var zahtev = _zahtevRepo.DobaviZahtevPoJmbgKorisnikaIStipendijaId(jmbg, stipendijaId);

            return zahtev != null;
        }

        public bool MogucnostDodavanjaAdmina()
        {
            var brojAdmina = _korisnikRepo.VratiSveAdmine().Count();

            string putanjaDoXml = @"C:\Users\mihaj\OneDrive\Radna površina\Stipendije\Stipendije\Podesavanja.xml";

            XDocument xmlDokument = XDocument.Load(putanjaDoXml);

            XElement maksimalanBrojAdminaElement = xmlDokument.Root.Element("MaksimalanBrojAdmina");

            if (int.TryParse(maksimalanBrojAdminaElement.Value, out int maksimalanBrojAdmina))
            {
                if (brojAdmina < maksimalanBrojAdmina)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
