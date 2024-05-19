using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Klase
{
    public class Korisnik
    {
        private string _jmbg;
        private string _ime;
        private string _prezime;
        private string _drzavljanstvo;
        private string _email;
        private string _lozinka;
        private bool _isAdmin;

        [Key]
        [RegularExpression(@"^[0-9]{13}$")]
        public string Jmbg
        {
            get => _jmbg;
            set => _jmbg = value;
        }

        [Required]
        [StringLength(20)]
        public string Ime
        {
            get => _ime;
            set => _ime = value;
        }

        [Required]
        [StringLength(40)]
        public string Prezime
        {
            get => _prezime;
            set => _prezime = value;
        }

        [Required]
        [StringLength(40)]
        public string Drzavljanstvo
        {
            get => _drzavljanstvo;
            set => _drzavljanstvo = value;
        }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}$")]
        public string Email
        {
            get => _email;
            set => _email = value;
        }

        [Required]
        [StringLength(20)]
        public string Lozinka
        {
            get => _lozinka;
            set => _lozinka = value;
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set => _isAdmin = value;
        }
    }

}
