using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWeb.Data;
namespace SchoolWeb.Services
{
    public interface ISchulService
    {
        Task<IEnumerable<Schueler>> GetAllSchuelerAsync();
        Task<Schueler?> GetSchuelerByIdAsync(int id);
        Task<Schueler> AddSchuelerAsync(Schueler schueler);
        Task<Schueler> UpdateSchuelerAsync(Schueler schueler);
        Task DeleteSchuelerAsync(int id);

        Task<IEnumerable<Klassenraum>> GetAllKlassenraeume();
        Task<Klassenraum?> GetKlassenraumByIdAsync(int id);
        Task<Klassenraum> AddKlassenraumAsync(Klassenraum klassenraum);
        Task<Klassenraum> UpdateKlassenraumAsync(Klassenraum klassenraum);
        Task DeleteKlassenraumAsync(int id);

        Task<double> BerechneFrauenanteilInProzentAsync(string klasse);
        Task<bool> KannKlasseUnterrichtenAsync(string klasse, int klassenraumId);
        Task<Dictionary<string, int>> GetAnzahlSchülerNachGeschlechtAsync();
        Task<IEnumerable<Klassenraum>> GetKlassenraeumeMitCynapAsync();

        Task<IEnumerable<Lehrer>> GetAllLehrerAsync();
        Task<Lehrer?> GetLehrerByIdAsync(int id);
        Task<Lehrer> AddLehrerAsync(Lehrer lehrer);
        Task<Lehrer> UpdateLehrerAsync(Lehrer lehrer);
        Task DeleteLehrerAsync(int id);
    }
        public class SchulService : ISchulService
        {
            private readonly SchoolDbContext _context;

            public SchulService(SchoolDbContext context)
            {
                _context = context;
            }

            // Schueler Methods
            public async Task<IEnumerable<Schueler>> GetAllSchuelerAsync()
            {
                return await _context.Schueler.ToListAsync();
            }

            public async Task<Schueler?> GetSchuelerByIdAsync(int id)
            {
                return await _context.Schueler.FindAsync(id);
            }

            public async Task<Schueler> AddSchuelerAsync(Schueler schueler)
            {
                var existing = await _context.Schueler
                    .FirstOrDefaultAsync(s => s.Geburtstag == schueler.Geburtstag && s.Klasse == schueler.Klasse);

                if (existing != null)
                {
                    throw new ArgumentException("Schüler mit diesem Geburtstag und dieser Klasse existiert bereits.");
                }

                _context.Schueler.Add(schueler);
                await _context.SaveChangesAsync();
                return schueler;
            }

            public async Task<Schueler> UpdateSchuelerAsync(Schueler schueler)
            {
                _context.Entry(schueler).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return schueler;
            }

            public async Task DeleteSchuelerAsync(int id)
            {
                var schueler = await _context.Schueler.FindAsync(id);
                if (schueler != null)
                {
                    _context.Schueler.Remove(schueler);
                    await _context.SaveChangesAsync();
                }
            }

            // Klassenraum Methods
            public async Task<IEnumerable<Klassenraum>> GetAllKlassenraeume()
            {
                return await _context.Klassenraeume.ToListAsync();
            }

            public async Task<Klassenraum?> GetKlassenraumByIdAsync(int id)
            {
                return await _context.Klassenraeume.FindAsync(id);
            }

            public async Task<Klassenraum> AddKlassenraumAsync(Klassenraum klassenraum)
            {
                _context.Klassenraeume.Add(klassenraum);
                await _context.SaveChangesAsync();
                return klassenraum;
            }

            public async Task<Klassenraum> UpdateKlassenraumAsync(Klassenraum klassenraum)
            {
                _context.Entry(klassenraum).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return klassenraum;
            }

            public async Task DeleteKlassenraumAsync(int id)
            {
                var klassenraum = await _context.Klassenraeume.FindAsync(id);
                if (klassenraum != null)
                {
                    _context.Klassenraeume.Remove(klassenraum);
                    await _context.SaveChangesAsync();
                }
            }

            // Business Logic Methods
            public async Task<double> BerechneFrauenanteilInProzentAsync(string klasse)
            {
                var schuelerInKlasse = await _context.Schueler
                    .Where(s => s.Klasse == klasse)
                    .ToListAsync();

                if (!schuelerInKlasse.Any())
                    return 0;

                var anzahlFrauen = schuelerInKlasse.Count(s => s.Geschlecht == "weiblich");
                return (double)anzahlFrauen / schuelerInKlasse.Count * 100;
            }

            public async Task<bool> KannKlasseUnterrichtenAsync(string klasse, int klassenraumId)
            {
                var schuelerAnzahl = await _context.Schueler
                    .CountAsync(s => s.Klasse == klasse);

                var klassenraum = await _context.Klassenraeume
                    .FindAsync(klassenraumId);

                return klassenraum != null && klassenraum.Plaetze >= schuelerAnzahl;
            }

            public async Task<Dictionary<string, int>> GetAnzahlSchülerNachGeschlechtAsync()
            {
                var schueler = await _context.Schueler.ToListAsync();
                return new Dictionary<string, int>
                {
                    ["männlich"] = schueler.Count(s => s.Geschlecht == "männlich"),
                    ["weiblich"] = schueler.Count(s => s.Geschlecht == "weiblich")
                };
            }

            public async Task<IEnumerable<Klassenraum>> GetKlassenraeumeMitCynapAsync()
            {
                return await _context.Klassenraeume
                    .Where(k => k.HasCynap)
                    .ToListAsync();
            }
        public async Task<IEnumerable<Lehrer>> GetAllLehrerAsync()
        {
            return await _context.Lehrer.ToListAsync();
        }

        public async Task<Lehrer?> GetLehrerByIdAsync(int id)
        {
            return await _context.Lehrer.FindAsync(id);
        }

        public async Task<Lehrer> AddLehrerAsync(Lehrer lehrer)
        {
            _context.Lehrer.Add(lehrer);
            await _context.SaveChangesAsync();
            return lehrer;
        }

        public async Task<Lehrer> UpdateLehrerAsync(Lehrer lehrer)
        {
            _context.Entry(lehrer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return lehrer;
        }

        public async Task DeleteLehrerAsync(int id)
        {
            var lehrer = await _context.Lehrer.FindAsync(id);
            if (lehrer != null)
            {
                _context.Lehrer.Remove(lehrer);
                await _context.SaveChangesAsync();
            }
        }
    }
    
}