using SchoolWeb.Models;
using SchoolWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Klasse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string Bezeichnung { get; set; } = string.Empty;

        [Range(1, 13)]
        public int Schulstufe { get; set; }

        [StringLength(50)]
        public string Ausbildungsrichtung { get; set; } = string.Empty;

        // Foreign Key
        public int? KlassenlehrerId { get; set; }
        public virtual Lehrer? Klassenlehrer { get; set; }

        // Navigation Properties
        public virtual ICollection<Schueler> Schueler { get; set; } = new List<Schueler>();

        public Klasse() { }

        public Klasse(string name, string bezeichnung, int schulstufe, string ausbildungsrichtung)
        {
            Name = name;
            Bezeichnung = bezeichnung;
            Schulstufe = schulstufe;
            Ausbildungsrichtung = ausbildungsrichtung;
        }
    }
}