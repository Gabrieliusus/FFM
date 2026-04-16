using SchoolWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SchoolWeb.Models
{
    public class Schueler : Person
    {
        [Required]
        [StringLength(10)]
        public string Klasse { get; set; } = string.Empty;

        [NotMapped]
        public List<string> Klassen { get; set; } = new List<string>();

        // Navigation Property
        public virtual ICollection<SchuelerKlassenraum> SchuelerKlassenraeume { get; set; } = new List<SchuelerKlassenraum>();

        public Schueler() : base() { }

        public Schueler(string klasse, DateTime geburtstag, string geschlecht)
            : base(geburtstag, geschlecht)
        {
            Klasse = klasse;
            AddKlasse(klasse);
        }

        public void AddKlasse(string klasse)
        {
            if (!Klassen.Contains(klasse))
            {
                Klassen.Add(klasse);
            }
        }

        public void ZähleSchülerProKlasse(List<Schueler> schuelerListe)
        {
            var klassenGruppen = schuelerListe.GroupBy(s => s.Klasse);
            foreach (var gruppe in klassenGruppen)
            {
                Console.WriteLine($"Klasse {gruppe.Key}: {gruppe.Count()} Schüler");
            }
        }
    }
}