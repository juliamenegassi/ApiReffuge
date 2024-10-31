using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiarioController : ControllerBase
    {
        private readonly IDiarioRepositorio _diarioRepositorio;

        public DiarioController(IDiarioRepositorio diarioRepositorio)
        {
            _diarioRepositorio = diarioRepositorio;
        }

        [HttpGet("GetAllDiarios")]
        public async Task<ActionResult<List<DiarioModel>>> GetAllDiarios()
        {
            List<DiarioModel> diario = await _diarioRepositorio.GetAll();
            return Ok(diario);
        }

        [HttpGet("GetDiarioId/{id}")]
        public async Task<ActionResult<DiarioModel>> GetDiarioId(int id)
        {
            DiarioModel diario = await _diarioRepositorio.GetById(id);
            return Ok(diario);
        }

        [HttpPost("DiarioUser")]
        public async Task<ActionResult<DiarioModel>> InsertDiario([FromBody] DiarioModel diarioModel)
        {
            DiarioModel diario = await _diarioRepositorio.InsertDiario(diarioModel);
            return Ok(diario);
        }

        [HttpPut("UpdateDiario/{id:int}")]
        public async Task<ActionResult<DiarioModel>> UpdateDiario(int id, [FromBody] DiarioModel diarioModel)
        {
            diarioModel.DiarioId = id;
            DiarioModel diario = await _diarioRepositorio.UpdateDiario(diarioModel, id);
            return Ok(diario);
        }

        [HttpDelete("DeleteDiario/{id:int}")]
        public async Task<ActionResult<DiarioModel>> DeleteDiario(int id)
        {
            bool deleted = await _diarioRepositorio.DeleteDiario(id);
            return Ok(deleted);
        }
    }
}
