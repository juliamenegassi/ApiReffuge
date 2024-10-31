using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController : ControllerBase
    {
        private readonly IPlanosRepositorio _planosRepositorio;

        public PlanosController(IPlanosRepositorio planosRepositorio)
        {
            _planosRepositorio = planosRepositorio;
        }

        [HttpGet("GetAllPlano")]
        public async Task<ActionResult<List<PlanosModel>>> GetAllPlano()
        {
            List<PlanosModel> planos = await _planosRepositorio.GetAll();
            return Ok(planos);
        }

        [HttpGet("GetPlanosId/{id}")]
        public async Task<ActionResult<PlanosModel>> GetPlanosId(int id)
        {
            PlanosModel planos = await _planosRepositorio.GetById(id);
            return Ok(planos);
        }

        [HttpPost("PlanosUser")]
        public async Task<ActionResult<PlanosModel>> InsertPlanos([FromBody] PlanosModel planosModel)
        {
            PlanosModel planos = await _planosRepositorio.InsertPlanos(planosModel);
            return Ok(planos);
        }

        [HttpPut("UpdatePlanos/{id:int}")]
        public async Task<ActionResult<PlanosModel>> UpdatePlanos(int id, [FromBody] PlanosModel planosModel)
        {
            planosModel.PlanosId = id;
            PlanosModel planos = await _planosRepositorio.UpdatePlanos(planosModel, id);
            return Ok(planos);
        }

        [HttpDelete("DeletePlanos/{id:int}")]
        public async Task<ActionResult<PlanosModel>> DeletePlanos(int id)
        {
            bool deleted = await _planosRepositorio.DeletePlanos(id);
            return Ok(deleted);
        }
    }
}
