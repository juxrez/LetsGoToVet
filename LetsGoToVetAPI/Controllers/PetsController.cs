using LetsGoToVet.Domain;
using LetsGoToVet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LetsGoToVetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet(Name = "GetAllPets")]
        public async Task<ActionResult<List<Pet>>> GetAll([FromQuery] string? name)
        {
            var response = await _petService.GetAllPets(name);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var response = await _petService.GetPet(id: id);

            return Ok(value: response);
        }

        [HttpPost]
        public async Task<ActionResult> AddPet(Pet newPet)
        {
            var createdPet = await _petService.CreatePetAsync(newPet);

            return Created(HttpContext.GetEndpoint().DisplayName, createdPet);
        }
    }
}