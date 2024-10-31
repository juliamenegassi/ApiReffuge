using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEspecializacaoController : ControllerBase
    {
            private readonly ITipoEspecializacaoRepositorio _tipoEspecializacaoRepositorio;

            public TipoEspecializacaoController(ITipoEspecializacaoRepositorio tipoEspecializacaoRepositorio)
            {
                _tipoEspecializacaoRepositorio = tipoEspecializacaoRepositorio;
            }

            [HttpGet("GetAllTipoEspecializacoes")]
            public async Task<ActionResult<List<TipoEspecializacaoModel>>> GetAllTipoEspecializacoes()
            {
                List<TipoEspecializacaoModel> tipoEspecializacao = await _tipoEspecializacaoRepositorio.GetAll();
                return Ok(tipoEspecializacao);
            }

            [HttpGet("GetTipoEspecializacaoId/{id}")]
            public async Task<ActionResult<TipoEspecializacaoModel>> GetTipoEspecializacaoId(int id)
            {
                TipoEspecializacaoModel tipoEspecializacao = await _tipoEspecializacaoRepositorio.GetById(id);
                return Ok(tipoEspecializacao);
            }

            [HttpPost("TipoEspecializacaoUser")]
            public async Task<ActionResult<TipoEspecializacaoModel>> InsertTipoEspecializacao([FromBody] TipoEspecializacaoModel tipoEspecializacaoModel)
            {
                TipoEspecializacaoModel tipoEspecializacao = await _tipoEspecializacaoRepositorio.InsertTipoEspecializacao(tipoEspecializacaoModel);
                return Ok(tipoEspecializacao);
            }

            [HttpPut("UpdateTipoEspecializacao/{id:int}")]
            public async Task<ActionResult<TipoEspecializacaoModel>> UpdateTipoEspecializacao(int id, [FromBody] TipoEspecializacaoModel tipoEspecializacaoModel)
            {
                tipoEspecializacaoModel.TipoEspecializacaoId = id;
                TipoEspecializacaoModel tipoEspecializacao = await _tipoEspecializacaoRepositorio.UpdateTipoEspecializacao(tipoEspecializacaoModel, id);
                return Ok(tipoEspecializacao);
            }

            [HttpDelete("DeleteTipoEspecializacao/{id:int}")]
            public async Task<ActionResult<bool>> DeleteTipoEspecializacao(int id)
            {
                bool deleted = await _tipoEspecializacaoRepositorio.DeleteTipoEspecializacao(id);
                return Ok(deleted);
            }
        }
    }

