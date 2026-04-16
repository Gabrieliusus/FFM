using SchoolWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Lehrer : Person
    {
        [Required]
        [StringLength(100)]
        public string Vorname { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nachname { get; set; } = string.Empty;

        [StringLength(10)]
        public string Kuerzel { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [StringLength(500)]
        public string BildUrl { get; set; } = string.Empty;

        [StringLength(200)]
        public string Fachbereich { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Erfahrung { get; set; } // Jahre

        public bool IstKlassenlehrer { get; set; }

        // Navigation Properties
        public virtual ICollection<Klasse> BetreulteKlassen { get; set; } = new List<Klasse>();

        public string VollName => $"{Vorname} {Nachname}";

        public Lehrer() : base() { }

        public Lehrer(string vorname, string nachname, string kuerzel, string email,
                      DateTime geburtstag, string geschlecht, string fachbereich)
            : base(geburtstag, geschlecht)
        {
            Vorname = vorname;
            Nachname = nachname;
            Kuerzel = kuerzel;
            Email = email;
            Fachbereich = fachbereich;
        }
    }
}