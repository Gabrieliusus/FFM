using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using SchoolWeb.Services;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlassenraumController : ControllerBase
    {
        private readonly ISchulService _schulService;

        public KlassenraumController(ISchulService schulService)
        {
            _schulService = schulService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klassenraum>>> GetAllKlassenraeume()
        {
            var klassenraeume = await _schulService.GetAllKlassenraeume();
            return Ok(klassenraeume);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Klassenraum>> GetKlassenraum(int id)
        {
            var klassenraum = await _schulService.GetKlassenraumByIdAsync(id);
            if (klassenraum == null)
            {
                return NotFound($"Klassenraum mit ID {id} wurde nicht gefunden.");
            }
            return Ok(klassenraum);
        }

        [HttpPost]
        public async Task<ActionResult<Klassenraum>> CreateKlassenraum([FromBody] Klassenraum klassenraum)
        {
            try
            {
                var neuerKlassenraum = await _schulService.AddKlassenraumAsync(klassenraum);
                return CreatedAtAction(nameof(GetKlassenraum), new { id = neuerKlassenraum.Id }, neuerKlassenraum);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Klassenraum>> UpdateKlassenraum(int id, [FromBody] Klassenraum klassenraum)
        {
            if (id != klassenraum.Id)
            {
                return BadRequest("ID stimmt nicht überein.");
            }

            try
            {
                var updatedKlassenraum = await _schulService.UpdateKlassenraumAsync(klassenraum);
                return Ok(updatedKlassenraum);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKlassenraum(int id)
        {
            await _schulService.DeleteKlassenraumAsync(id);
            return NoContent();
        }

        [HttpGet("cynap")]
        public async Task<ActionResult<IEnumerable<Klassenraum>>> GetKlassenraeumeMitCynap()
        {
            var klassenraeume = await _schulService.GetKlassenraeumeMitCynapAsync();
            return Ok(klassenraeume);
        }
    }
}