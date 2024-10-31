using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEmocaoController : ControllerBase
    {
        private readonly ITipoEmocaoRepositorio _tipoEmocaoRepositorio;

        public TipoEmocaoController(ITipoEmocaoRepositorio tipoEmocaoRepositorio)
        {
            _tipoEmocaoRepositorio = tipoEmocaoRepositorio;
        }

        [HttpGet("GetAllTipoEmocoes")]
        public async Task<ActionResult<List<TipoEmocaoModel>>> GetAllTipoEmocoes()
        {
            List<TipoEmocaoModel> tipoEmocao = await _tipoEmocaoRepositorio.GetAll();
            return Ok(tipoEmocao);
        }

        [HttpGet("GetTipoEmocaoId/{id}")]
        public async Task<ActionResult<TipoEmocaoModel>> GetTipoEmocaoId(int id)
        {
            TipoEmocaoModel tipoEmocao = await _tipoEmocaoRepositorio.GetById(id);
            return Ok(tipoEmocao);
        }

        [HttpPost("TipoEmocaoUser")]
        public async Task<ActionResult<TipoEmocaoModel>> InsertTipoEmocao([FromBody] TipoEmocaoModel tipoEmocaoModel)
        {
            TipoEmocaoModel tipoEmocao = await _tipoEmocaoRepositorio.InsertTipoEmocao(tipoEmocaoModel);
            return Ok(tipoEmocao);
        }

        [HttpPut("UpdateEmocao/{id:int}")]
        public async Task<ActionResult<TipoEmocaoModel>> UpdateTipoEmocao(int id, [FromBody] TipoEmocaoModel tipoEmocaoModel)
        {
            tipoEmocaoModel.TipoEmocaoId = id;
            TipoEmocaoModel tipoEmocao = await _tipoEmocaoRepositorio.UpdateTipoEmocao(tipoEmocaoModel, id);
            return Ok(tipoEmocao);
        }

        [HttpDelete("DeleteTipoEmocao/{id:int}")]
        public async Task<ActionResult<TipoEmocaoModel>> DeleteTipoEmocao(int id)
        {
            bool deleted = await _tipoEmocaoRepositorio.DeleteTipoEmocao(id);
            return Ok(deleted);
        }
    }
}
