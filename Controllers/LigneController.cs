using CarteAPI.Models;
using CarteAPI.Services.LigneService;
using Microsoft.AspNetCore.Mvc;

namespace CarteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigneController : ControllerBase
    {
        private readonly ILigneService _ligneService;

        public LigneController(ILigneService ligneService)
        {
            _ligneService = ligneService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ligne>>> GetAllLignes()
        {
            var lignes = await _ligneService.GetAllLignes();
            return Ok(lignes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ligne>> GetSingleLigne(int id)
        {
            var ligne = await _ligneService.GetSingleLigne(id);
            if (ligne == null)
            {
                return NotFound();
            }
            return Ok(ligne);
        }

        [HttpPost]
        public async Task<ActionResult<Ligne>> AddLigne([FromBody] Ligne ligne)
        {
            var newLigne = await _ligneService.AddLigne(ligne);
            return CreatedAtAction(nameof(GetSingleLigne), new { id = newLigne.Id }, newLigne);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLigne(int id, [FromBody] Ligne ligne)
        {
            var updatedLigne = await _ligneService.UpdateLigne(id, ligne);
            if (updatedLigne == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLigne(int id)
        {
            var deletedLigne = await _ligneService.DeleteLigne(id);
            if (deletedLigne == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
