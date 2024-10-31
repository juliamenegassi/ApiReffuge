using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuracaoSonoController : ControllerBase
    {
        private readonly IDuracaoSonoRepositorio _duracaoSonoRepositorio;

        public DuracaoSonoController(IDuracaoSonoRepositorio duracaoSonoRepositorio)
        {
            _duracaoSonoRepositorio = duracaoSonoRepositorio;
        }

        [HttpGet("GetAllDuracaoSonos")]
        public async Task<ActionResult<List<DuracaoSonoModel>>> GetAllDuracaoSonos()
        {
            List<DuracaoSonoModel> duracaoSono = await _duracaoSonoRepositorio.GetAll();
            return Ok(duracaoSono);
        }

        [HttpGet("GetDuracaoSonoId/{id}")]
        public async Task<ActionResult<DuracaoSonoModel>> GetDuracaoSonoId(int id)
        {
            DuracaoSonoModel duracaoSono = await _duracaoSonoRepositorio.GetById(id);
            return Ok(duracaoSono);
        }

        [HttpPost("DuracaoSonoUser")]
        public async Task<ActionResult<DuracaoSonoModel>> InsertDuracaoSono([FromBody] DuracaoSonoModel duracaoSonoModel)
        {
            DuracaoSonoModel duracaoSono = await _duracaoSonoRepositorio.InsertDuracaoSono(duracaoSonoModel);
            return Ok(duracaoSono);
        }

        [HttpPut("UpdateDuracaoSono/{id:int}")]
        public async Task<ActionResult<DuracaoSonoModel>> UpdateDuracaoSono(int id, [FromBody] DuracaoSonoModel duracaoSonoModel)
        {
            duracaoSonoModel.DuracaoSonoId = id;
            DuracaoSonoModel duracaoSono = await _duracaoSonoRepositorio.UpdateDuracaoSono(duracaoSonoModel, id);
            return Ok(duracaoSono);
        }

        [HttpDelete("DeleteDuracaoSono/{id:int}")]
        public async Task<ActionResult<DuracaoSonoModel>> DeleteDuracaoSono(int id)
        {
            bool deleted = await _duracaoSonoRepositorio.DeleteDuracaoSono(id);
            return Ok(deleted);
        }
    }
}
