using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using SchoolWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LehrerController : ControllerBase
    {
        private readonly ISchulService _schulService;

        public LehrerController(ISchulService schulService)
        {
            _schulService = schulService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lehrer>>> GetAllLehrer()
        {
            var lehrer = await _schulService.GetAllLehrerAsync();
            return Ok(lehrer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lehrer>> GetLehrerById(int id)
        {
            var lehrer = await _schulService.GetLehrerByIdAsync(id);
            if (lehrer == null)
                return NotFound();
            return Ok(lehrer);
        }

        [HttpPost]
        public async Task<ActionResult<Lehrer>> AddLehrer(Lehrer lehrer)
        {
            var created = await _schulService.AddLehrerAsync(lehrer);
            return CreatedAtAction(nameof(GetLehrerById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Lehrer>> UpdateLehrer(int id, Lehrer lehrer)
        {
            if (id != lehrer.Id)
                return BadRequest();

            var updated = await _schulService.UpdateLehrerAsync(lehrer);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLehrer(int id)
        {
            await _schulService.DeleteLehrerAsync(id);
            return NoContent();
        }
    }
}