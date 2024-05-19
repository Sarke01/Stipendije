using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Interfejsi
{
    public interface IKorisnikRepo
    {
        DataSet DajSveKorisnike();
        DataSet DajKorisnikaPoPrezimenu(string Prezime);
        bool NoviKorisnik(Korisnik objNoviKorisnik);
        bool DodajAdmina(Korisnik objNoviKorisnik);
        bool ObrisiKorisnika(string JMBG);
        bool IzmeniKorisnika(string StariJMBG, Korisnik objNoviKorisnik);
        bool IzmeniKorisnika(Korisnik objKorisnik);
        Korisnik PronadjiPoEmail(string email);
        List<Korisnik> VratiSveAdmine();

    }
}
