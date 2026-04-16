using SchoolWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Klassenraum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000)]
        public float RaumInQm { get; set; }

        [Required]
        [Range(1, 100)]
        public int Plaetze { get; set; }

        public bool HasCynap { get; set; }

        // Navigation Properties
        public virtual ICollection<SchuelerKlassenraum> SchuelerKlassenraeume { get; set; } = new List<SchuelerKlassenraum>();

        public Klassenraum() { }

        public Klassenraum(string name, float raumInQm, int plaetze, bool hasCynap)
        {
            Name = name;
            RaumInQm = raumInQm;
            Plaetze = plaetze;
            HasCynap = hasCynap;
        }
    }
}