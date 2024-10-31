using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudoController : ControllerBase
    {
        private readonly IConteudoRepositorio _conteudoRepositorio;

        public ConteudoController(IConteudoRepositorio conteudoRepositorio)
        {
            _conteudoRepositorio = conteudoRepositorio;
        }

        [HttpGet("GetAllConteudos")]
        public async Task<ActionResult<List<ConteudoModel>>> GetAllConteudos()
        {
            List<ConteudoModel> conteudo = await _conteudoRepositorio.GetAll();
            return Ok(conteudo);
        }

        [HttpGet("GetConteudoId/{id}")]
        public async Task<ActionResult<ConteudoModel>> GetConteudoId(int id)
        {
            ConteudoModel conteudo = await _conteudoRepositorio.GetById(id);
            return Ok(conteudo);
        }

        [HttpPost("ConteudoUser")]
        public async Task<ActionResult<ConteudoModel>> InsertConteudo([FromBody] ConteudoModel conteudoModel)
        {
            ConteudoModel conteudo = await _conteudoRepositorio.InsertConteudo(conteudoModel);
            return Ok(conteudo);
        }

        [HttpPut("UpdateConteudo/{id:int}")]
        public async Task<ActionResult<ConteudoModel>> UpdateConteudo(int id, [FromBody] ConteudoModel conteudoModel)
        {
            conteudoModel.ConteudoId = id;
            ConteudoModel conteudo = await _conteudoRepositorio.UpdateConteudo(conteudoModel, id);
            return Ok(conteudo);
        }

        [HttpDelete("DeleteConteudo/{id:int}")]
        public async Task<ActionResult<ConteudoModel>> DeleteConteudo(int id)
        {
            bool deleted = await _conteudoRepositorio.DeleteConteudo(id);
            return Ok(deleted);
        }
    }
}
