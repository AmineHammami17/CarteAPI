using CarteAPI.Models;
using CarteAPI.Services.EquipeService;
using Microsoft.AspNetCore.Mvc;

namespace CarteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeService _equipeService;

        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipe>>> GetAllEquipes()
        {
            var equipes = await _equipeService.GetAllEquipes();
            return Ok(equipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetSingleEquipe(int id)
        {
            var equipe = await _equipeService.GetSingleEquipe(id);
            if (equipe == null)
            {
                return NotFound();
            }
            return Ok(equipe);
        }

        [HttpPost]
        public async Task<ActionResult<Equipe>> AddEquipe([FromBody] Equipe equipe)
        {
            var newEquipe = await _equipeService.AddEquipe(equipe);
            return CreatedAtAction(nameof(GetSingleEquipe), new { id = newEquipe.Id }, newEquipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipe(int id, [FromBody] Equipe equipe)
        {
            var updatedEquipe = await _equipeService.UpdateEquipe(id, equipe);
            if (updatedEquipe == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipe(int id)
        {
            var deletedEquipe = await _equipeService.DeleteEquipe(id);
            if (deletedEquipe == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
