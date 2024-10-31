using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSentimentoSonoController : ControllerBase
    {
        private readonly ITipoSentimentoSonoRepositorio _tipoSentimentoSonoRepositorio;

        public TipoSentimentoSonoController(ITipoSentimentoSonoRepositorio tipoSentimentoSonoRepositorio)
        {
            _tipoSentimentoSonoRepositorio = tipoSentimentoSonoRepositorio;
        }

        [HttpGet("GetAllTipoSentimentoSonos")]
        public async Task<ActionResult<List<TipoSentimentoSonoModel>>> GetAllTipoSentimentoSonos()
        {
            List<TipoSentimentoSonoModel> tipoSentimentoSono = await _tipoSentimentoSonoRepositorio.GetAll();
            return Ok(tipoSentimentoSono);
        }

        [HttpGet("GetTipoSentimentoSonoId/{id}")]
        public async Task<ActionResult<TipoSentimentoSonoModel>> GetTipoSentimentoSonoId(int id)
        {
            TipoSentimentoSonoModel tipoSentimentoSono = await _tipoSentimentoSonoRepositorio.GetById(id);
            return Ok(tipoSentimentoSono);
        }

        [HttpPost("TipoSentimentoSonoUser")]
        public async Task<ActionResult<TipoSentimentoSonoModel>> InsertTipoSentimentoSono([FromBody] TipoSentimentoSonoModel tipoSentimentoSonoModel)
        {
            TipoSentimentoSonoModel tipoSentimentoSono = await _tipoSentimentoSonoRepositorio.InsertTipoSentimentoSono(tipoSentimentoSonoModel);
            return Ok(tipoSentimentoSono);
        }

        [HttpPut("UpdateTipoSentimentoSono/{id:int}")]
        public async Task<ActionResult<TipoSentimentoSonoModel>> UpdateTipoSentimentoSono(int id, [FromBody] TipoSentimentoSonoModel tipoSentimentoSonoModel)
        {
            tipoSentimentoSonoModel.TipoSentimentoSonoId = id;
            TipoSentimentoSonoModel tipoSentimentoSono = await _tipoSentimentoSonoRepositorio.UpdateTipoSentimentoSono(tipoSentimentoSonoModel, id);
            return Ok(tipoSentimentoSono);
        }

        [HttpDelete("DeleteTipoSentimentoSono/{id:int}")]
        public async Task<ActionResult<TipoSentimentoSonoModel>> DeleteTipoSentimentoSono(int id)
        {
            bool deleted = await _tipoSentimentoSonoRepositorio.DeleteTipoSentimentoSono(id);
            return Ok(deleted);
        }
    }
}
