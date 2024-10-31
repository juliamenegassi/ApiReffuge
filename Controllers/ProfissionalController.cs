using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;

        public ProfissionalController(IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio = profissionalRepositorio;
        }

        [HttpGet("GetAllProfissionais")]
        public async Task<ActionResult<List<ProfissionalModel>>> GetAllProfissionais()
        {
            List<ProfissionalModel> profissional = await _profissionalRepositorio.GetAll();
            return Ok(profissional);
        }

        [HttpGet("GetProfissionalId/{id}")]
        public async Task<ActionResult<ProfissionalModel>> GetProfissionalId(int id)
        {
            ProfissionalModel profissional = await _profissionalRepositorio.GetById(id);
            return Ok(profissional);
        }

        [HttpPost("ProfissionalUser")]
        public async Task<ActionResult<ProfissionalModel>> InsertProfissional([FromBody] ProfissionalModel profissionalModel)
        {
            ProfissionalModel profissional = await _profissionalRepositorio.InsertProfissional(profissionalModel);
            return Ok(profissional);
        }

        [HttpPut("UpdateProfissional/{id:int}")]
        public async Task<ActionResult<ProfissionalModel>> UpdateProfissional(int id, [FromBody] ProfissionalModel profissionalModel)
        {
            profissionalModel.ProfissionalId = id;
            ProfissionalModel profissional = await _profissionalRepositorio.UpdateProfissional(profissionalModel, id);
            return Ok(profissional);
        }

        [HttpDelete("DeleteProfissional/{id:int}")]
        public async Task<ActionResult<ProfissionalModel>> DeleteProfissional(int id)
        {
            bool deleted = await _profissionalRepositorio.DeleteProfissional(id);
            return Ok(deleted);
        }
    }
}
