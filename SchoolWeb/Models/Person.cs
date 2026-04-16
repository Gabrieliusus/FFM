using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        private string _geschlecht = string.Empty;

        [Required]
        [StringLength(20)]
        public string Geschlecht
        {
            get => _geschlecht;
            set
            {
                if (value != "männlich" && value != "weiblich" && value != "Männlich" && value != "Weiblich")
                {
                    throw new ArgumentException("Ungültiges Geschlecht eingegeben!");
                }
                _geschlecht = value;
            }
        }

        [Required]
        public DateTime Geburtstag { get; set; }

        public int Alter => DateTime.Today.Year - Geburtstag.Year;

        protected Person() { }

        protected Person(DateTime geburtstag, string geschlecht)
        {
            Geburtstag = geburtstag;
            Geschlecht = geschlecht;
        }
    }
}