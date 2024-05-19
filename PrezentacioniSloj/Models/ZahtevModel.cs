using System.ComponentModel.DataAnnotations;

namespace PrezentacioniSloj.Models
{
    public class ZahtevModel
    {
        public int Id { get; set; }
        public string? JmbgKorisnika { get; set; }
        public int StipendijaId { get; set; }
        public string? Razlozi { get; set; }
        public bool FinansijskaPotreba { get; set; }
        public bool DrustvenoAngazovanje { get; set; }
        [Required(ErrorMessage = "Akademski uspeh je obavezan.")]
        public double AkademskiUspeh { get; set; }
    }
}
