using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermometroNoturnoControllerr : ControllerBase
    {
        private readonly ITermometroNoturnoRepositorio _termometroNoturnoRepositorio;

        public TermometroNoturnoControllerr(ITermometroNoturnoRepositorio termometroNoturnoRepositorio)
        {
            _termometroNoturnoRepositorio = termometroNoturnoRepositorio;
        }

        [HttpGet("GetAllTermometrosNoturnos")]
        public async Task<ActionResult<List<TermometroNoturnoModel>>> GetAllProdutosTermometrosNoturnos()
        {
            List<TermometroNoturnoModel> termometroNoturno = await _termometroNoturnoRepositorio.GetAll();
            return Ok(termometroNoturno);
        }

        [HttpGet("GetTermometroNoturnoId/{id}")]
        public async Task<ActionResult<TermometroNoturnoModel>> GetTermometroNoturnoId(int id)
        {
            TermometroNoturnoModel termometroNoturno = await _termometroNoturnoRepositorio.GetById(id);
            return Ok(termometroNoturno);
        }

        [HttpPost("TermometroNoturnoUser")]
        public async Task<ActionResult<TermometroNoturnoModel>> InsertTermometroNoturno([FromBody] TermometroNoturnoModel termometroNoturnoModel)
        {
            TermometroNoturnoModel termometroNoturno = await _termometroNoturnoRepositorio.InsertTermometroNoturno(termometroNoturnoModel);
            return Ok(termometroNoturno);
        }

        [HttpPut("UpdateTermometroNoturno/{id:int}")]
        public async Task<ActionResult<TermometroNoturnoModel>> UpdateTermometroNoturno(int id, [FromBody] TermometroNoturnoModel termometroNoturnoModel)
        {
            termometroNoturnoModel.TermometroNoturnoId = id;
            TermometroNoturnoModel termometroNoturno = await _termometroNoturnoRepositorio.UpdateTermometroNoturno(termometroNoturnoModel, id);
            return Ok(termometroNoturno);
        }

        [HttpDelete("DeleteTermometroNoturno/{id:int}")]
        public async Task<ActionResult<TermometroNoturnoModel>> DeleteTermometroNoturno(int id)
        {
            bool deleted = await _termometroNoturnoRepositorio.DeleteTermometroNoturno(id);
            return Ok(deleted);
        }
    }
}
