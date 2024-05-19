using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Klase
{
    public class Kriterijum
    {
        private int _id;
        private double _akademskiUspeh;
        private bool _drustvenoAngazovanje;
        private bool _finansijskaPotreba;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public double AkademskiUspeh
        {
            get => _akademskiUspeh;
            set => _akademskiUspeh = value;
        }

        public bool DrustvenoAngazovanje
        {
            get => _drustvenoAngazovanje;
            set => _drustvenoAngazovanje = value;
        }

        public bool FinansijskaPotreba
        {
            get => _finansijskaPotreba;
            set => _finansijskaPotreba = value;
        }
    }

}
