using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using SchoolWeb.Services;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchuelerController : ControllerBase
    {
        private readonly ISchulService _schulService;

        public SchuelerController(ISchulService schulService)
        {
            _schulService = schulService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schueler>>> GetAllSchueler()
        {
            var schueler = await _schulService.GetAllSchuelerAsync();
            return Ok(schueler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schueler>> GetSchueler(int id)
        {
            var schueler = await _schulService.GetSchuelerByIdAsync(id);
            if (schueler == null)
            {
                return NotFound($"Schüler mit ID {id} wurde nicht gefunden.");
            }
            return Ok(schueler);
        }

        [HttpPost]
        public async Task<ActionResult<Schueler>> CreateSchueler([FromBody] Schueler schueler)
        {
            try
            {
                var neuerSchueler = await _schulService.AddSchuelerAsync(schueler);
                return CreatedAtAction(nameof(GetSchueler), new { id = neuerSchueler.Id }, neuerSchueler);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Schueler>> UpdateSchueler(int id, [FromBody] Schueler schueler)
        {
            if (id != schueler.Id)
            {
                return BadRequest("ID stimmt nicht überein.");
            }

            try
            {
                var updatedSchueler = await _schulService.UpdateSchuelerAsync(schueler);
                return Ok(updatedSchueler);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchueler(int id)
        {
            await _schulService.DeleteSchuelerAsync(id);
            return NoContent();
        }
    }
}