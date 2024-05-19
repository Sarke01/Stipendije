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
    public class StipendijaServis
    {
        private readonly IStipendijaRepo _stipendijaRepo;

        public StipendijaServis(IStipendijaRepo stipendijaRepo)
        {
            _stipendijaRepo = stipendijaRepo;
        }

        public List<Stipendija> DajSveStipendije()
        {
            return _stipendijaRepo.DajSveStipendije();
        }
    }
}
