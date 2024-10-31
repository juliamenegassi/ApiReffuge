using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermometroEmocionalController : ControllerBase
    {
        private readonly ITermometroEmocionalRepositorio _termometroEmocionalRepositorio;

        public TermometroEmocionalController(ITermometroEmocionalRepositorio termometroEmocionalRepositorio)
        {
            _termometroEmocionalRepositorio = termometroEmocionalRepositorio;
        }

        [HttpGet("GetAllTermometrosEmocionais")]
        public async Task<ActionResult<List<TermometroEmocionalModel>>> GetAllProdutosTermometrosEmocionais()
        {
            List<TermometroEmocionalModel> termometroEmocional = await _termometroEmocionalRepositorio.GetAll();
            return Ok(termometroEmocional);
        }

        [HttpGet("GetTermometroEmocionalId/{id}")]
        public async Task<ActionResult<TermometroEmocionalModel>> GetTermometroEmocionalId(int id)
        {
            TermometroEmocionalModel termometroEmocional = await _termometroEmocionalRepositorio.GetById(id);
            return Ok(termometroEmocional);
        }

        [HttpPost("TermometroEmocionalUser")]
        public async Task<ActionResult<TermometroEmocionalModel>> InsertTermometroEmocional([FromBody] TermometroEmocionalModel termometroEmocionalModel)
        {
            TermometroEmocionalModel termometroEmocional = await _termometroEmocionalRepositorio.InsertTermometroEmocional(termometroEmocionalModel);
            return Ok(termometroEmocional);
        }

        [HttpPut("UpdateTermometroEmocional/{id:int}")]
        public async Task<ActionResult<TermometroEmocionalModel>> UpdateTermometroEmocional(int id, [FromBody] TermometroEmocionalModel termometroEmocionalModel)
        {
            termometroEmocionalModel.TermometroEmocionalId = id;
            TermometroEmocionalModel termometroEmocional = await _termometroEmocionalRepositorio.UpdateTermometroEmocional(termometroEmocionalModel, id);
            return Ok(termometroEmocional);
        }

        [HttpDelete("DeleteTermometroEmocional/{id:int}")]
        public async Task<ActionResult<TermometroEmocionalModel>> DeleteTermometroEmocional(int id)
        {
            bool deleted = await _termometroEmocionalRepositorio.DeleteTermometroEmocional(id);
            return Ok(deleted);
        }
    }
}
