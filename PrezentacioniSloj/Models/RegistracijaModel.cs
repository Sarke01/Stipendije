using System.ComponentModel.DataAnnotations;

namespace PrezentacioniSloj.Models
{
    public class RegistracijaModel
    {
        [Required(ErrorMessage = "JMBG je obavezan")]
        [StringLength(13, ErrorMessage = "JMBG mora imati tacno 13 cifara")]
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "JMBG mora imati tacno 13 cifara")]
        public string JMBG { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(40, ErrorMessage = "Ime ne sme biti duze od 40 karaktera")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(40, ErrorMessage = "Prezime ne sme biti duze od 40 karaktera")]
        public string Prezime { get; set; }


        [Required(ErrorMessage = "Email adresa je obavezna")]
        [EmailAddress(ErrorMessage = "Neispravna email adresa")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna")]
        [MinLength(5, ErrorMessage = "Lozinka mora imati najmanje 5 karaktera")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [Required(ErrorMessage = "Drzavljanstvo je obavezno.")]
        [StringLength(40, ErrorMessage = "Drzavljanstvo ne sme biti duze od 40 karaktera")]
        public string Drzavljanstvo { get; set; }

        public bool isAdmin { get; set; }

    }
}
