using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class SchuelerKlassenraum
    {
        [Key]
        public int Id { get; set; }

        public int SchuelerId { get; set; }
        public virtual Schueler Schueler { get; set; } = null!;

        public int KlassenraumId { get; set; }
        public virtual Klassenraum Klassenraum { get; set; } = null!;
    }
}