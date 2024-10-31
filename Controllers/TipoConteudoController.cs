using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoConteudoController : ControllerBase
    {
        private readonly ITipoConteudoRepositorio _tipoConteudoRepositorio;

        public TipoConteudoController(ITipoConteudoRepositorio tipoConteudoRepositorio)
        {
            _tipoConteudoRepositorio = tipoConteudoRepositorio;
        }

        [HttpGet("GetAllTipoConteudos")]
        public async Task<ActionResult<List<TipoConteudoModel>>> GetAllTipoConteudos()
        {
            List<TipoConteudoModel> tipoConteudo = await _tipoConteudoRepositorio.GetAll();
            return Ok(tipoConteudo);
        }

        [HttpGet("GetTipoConteudoId/{id}")]
        public async Task<ActionResult<TipoConteudoModel>> GetTipoConteudoId(int id)
        {
            TipoConteudoModel tipoConteudo = await _tipoConteudoRepositorio.GetById(id);
            return Ok(tipoConteudo);
        }

        [HttpPost("TipoConteudoUser")]
        public async Task<ActionResult<TipoConteudoModel>> InsertTipoConteudo([FromBody] TipoConteudoModel tipoConteudoModel)
        {
            TipoConteudoModel tipoConteudo = await _tipoConteudoRepositorio.InsertTipoConteudo(tipoConteudoModel);
            return Ok(tipoConteudo);
        }

        [HttpPut("UpdateTipoConteudo/{id:int}")]
        public async Task<ActionResult<TipoConteudoModel>> UpdateTipoConteudo(int id, [FromBody] TipoConteudoModel tipoConteudoModel)
        {
            tipoConteudoModel.TipoConteudoId = id;
            TipoConteudoModel tipoConteudo = await _tipoConteudoRepositorio.UpdateTipoConteudo(tipoConteudoModel, id);
            return Ok(tipoConteudo);
        }

        [HttpDelete("DeleteTipoConteudo/{id:int}")]
        public async Task<ActionResult<TipoConteudoModel>> DeleteTipoConteudo(int id)
        {
            bool deleted = await _tipoConteudoRepositorio.DeleteTipoConteudo(id);
            return Ok(deleted);
        }
    }
}
