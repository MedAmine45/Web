using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAtrioEmployeManagement.Data;
using WebAtrioEmployeManagement.DTOS;
using WebAtrioEmployeManagement.Services;

namespace WebAtrioEmployeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly IPersonneService _personneService;

        public PersonnesController(IPersonneService personneService)
        {
            _personneService = personneService;
        }

        [HttpPost]
        public async Task<IActionResult> AjouterPersonne([FromBody] PersonneDTO personneDto)
        {
            try
            {
                var result = await _personneService.CreatePersonneAsync(personneDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/emploi")]
        public async Task<IActionResult> AjouterEmploi(int id, [FromBody] EmploiDTO emploiDto)
        {
            try
            {
                var result = await _personneService.AddEmploiAsync(id, emploiDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonnes()
        {
            var result = await _personneService.GetAllPersonnesAsync();
            return Ok(result);
        }

        [HttpGet("entreprise/{nomEntreprise}")]
        public async Task<IActionResult> GetPersonnesParEntreprise(string nomEntreprise)
        {
            var result = await _personneService.GetPersonnesParEntrepriseAsync(nomEntreprise);
            return Ok(result);
        }

        [HttpGet("{id}/emplois")]
        public async Task<IActionResult> GetEmploisParDates(int id, [FromQuery] DateTime dateDebut, [FromQuery] DateTime dateFin)
        {
            var result = await _personneService.GetEmploisParDatesAsync(id, dateDebut, dateFin);
            return Ok(result);
        }
    }
}
