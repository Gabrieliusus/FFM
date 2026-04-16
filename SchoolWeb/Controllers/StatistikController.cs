using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Services;

namespace SchoolWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatistikController : ControllerBase
    {
        private readonly ISchulService _schulService;

        public StatistikController(ISchulService schulService)
        {
            _schulService = schulService;
        }

        [HttpGet("frauenanteil")]
        public async Task<ActionResult<IEnumerable<object>>> GetFrauenanteilAll()
        {
            var schueler = await _schulService.GetAllSchuelerAsync();
            var klassen = schueler.Select(s => s.Klasse).Distinct();

            var result = new List<object>();
            foreach (var klasse in klassen)
            {
                var anteil = await _schulService.BerechneFrauenanteilInProzentAsync(klasse);
                result.Add(new { klasse, anteil });
            }
            return Ok(result);
        }

        [HttpGet("durchschnittsalter")]
        public async Task<ActionResult<IEnumerable<object>>> GetDurchschnittsalterProKlasse()
        {
            var schueler = await _schulService.GetAllSchuelerAsync();
            var klassen = schueler.Select(s => s.Klasse).Distinct();

            var result = new List<object>();
            foreach (var klasse in klassen)
            {
                var schuelerInKlasse = schueler.Where(s => s.Klasse == klasse).ToList();
                if (schuelerInKlasse.Any())
                {
                    var alter = schuelerInKlasse.Average(s => s.Alter);
                    result.Add(new { klasse, alter });
                }
            }
            return Ok(result);
        }

        [HttpGet("geschlechterverteilung")]
        public async Task<ActionResult<IEnumerable<object>>> GetGeschlechterverteilung()
        {
            var verteilung = await _schulService.GetAnzahlSchülerNachGeschlechtAsync();
            var result = verteilung.Select(kv => new { geschlecht = kv.Key, anzahl = kv.Value }).ToList();
            return Ok(result);
        }

        [HttpGet("kann-unterrichten/{klasse}/{klassenraumId}")]
        public async Task<ActionResult<bool>> KannKlasseUnterrichten(string klasse, int klassenraumId)
        {
            var kannUnterrichten = await _schulService.KannKlasseUnterrichtenAsync(klasse, klassenraumId);
            return Ok(kannUnterrichten);
        }
    }
}