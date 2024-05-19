using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Interfejsi
{
    public interface IStipendijaRepo
    {
        List<Stipendija> DajSveStipendije();
        Stipendija DobaviStipendijuPoId(int stipendijaId);
    }
}
