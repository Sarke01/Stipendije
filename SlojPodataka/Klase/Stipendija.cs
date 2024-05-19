using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Klase
{
    public class Stipendija
    {
        private int _id;
        private string? _naziv;
        private decimal _iznos;
        private DateTime _datumPocetka;
        private DateTime _datumKraja;
        private Kriterijum? _kriterijum;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Naziv
        {
            get => _naziv;
            set => _naziv = value;
        }

        public decimal Iznos
        {
            get => _iznos;
            set => _iznos = value;
        }

        public DateTime DatumPocetka
        {
            get => _datumPocetka;
            set => _datumPocetka = value;
        }

        public DateTime DatumKraja
        {
            get => _datumKraja;
            set => _datumKraja = value;
        }

        public Kriterijum Kriterijum
        {
            get => _kriterijum;
            set => _kriterijum = value;
        }
    }

}
