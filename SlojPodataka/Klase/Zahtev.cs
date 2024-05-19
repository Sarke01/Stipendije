using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Klase
{
    public class Zahtev
    {
        private int _id;
        private string _jmbgKorisnika;
        private int _stipendijaId;
        private string _razlozi;
        private bool _finansijskaPotreba;
        private bool _drustvenoAngazovanje;
        private double _akademskiUspeh;
        private string _status;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string JmbgKorisnika
        {
            get => _jmbgKorisnika;
            set => _jmbgKorisnika = value;
        }

        public int StipendijaId
        {
            get => _stipendijaId;
            set => _stipendijaId = value;
        }

        public string Razlozi
        {
            get => _razlozi;
            set => _razlozi = value;
        }

        public bool FinansijskaPotreba
        {
            get => _finansijskaPotreba;
            set => _finansijskaPotreba = value;
        }

        public bool DrustvenoAngazovanje
        {
            get => _drustvenoAngazovanje;
            set => _drustvenoAngazovanje = value;
        }

        public double AkademskiUspeh
        {
            get => _akademskiUspeh;
            set => _akademskiUspeh = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }
    }

}
