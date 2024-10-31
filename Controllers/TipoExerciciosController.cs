using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExerciciosController : ControllerBase
    {
        private readonly ITipoExerciciosRepositorio _tipoExerciciosRepositorio;

        public TipoExerciciosController(ITipoExerciciosRepositorio tipoExerciciosRepositorio)
        {
            _tipoExerciciosRepositorio = tipoExerciciosRepositorio;
        }

        [HttpGet("GetAllTipoExercicios")]
        public async Task<ActionResult<List<TipoExerciciosModel>>> GetAllTipoExercicios()
        {
            List<TipoExerciciosModel> tipoExercicios = await _tipoExerciciosRepositorio.GetAll();
            return Ok(tipoExercicios);
        }

        [HttpGet("GetTipoExerciciosId/{id}")]
        public async Task<ActionResult<TipoExerciciosModel>> GetTipoExerciciosId(int id)
        {
            TipoExerciciosModel tipoExercicios = await _tipoExerciciosRepositorio.GetById(id);
            return Ok(tipoExercicios);
        }

        [HttpPost("TipoExerciciosUser")]
        public async Task<ActionResult<TipoExerciciosModel>> InsertTipoExercicios([FromBody] TipoExerciciosModel tipoExerciciosModel)
        {
            TipoExerciciosModel tipoExercicios = await _tipoExerciciosRepositorio.InsertTipoExercicios(tipoExerciciosModel);
            return Ok(tipoExercicios);
        }

        [HttpPut("UpdateTipoExercicios/{id:int}")]
        public async Task<ActionResult<TipoExerciciosModel>> UpdateTipoExercicios(int id, [FromBody] TipoExerciciosModel tipoExerciciosModel)
        {
            tipoExerciciosModel.TipoExerciciosId = id;
            TipoExerciciosModel tipoExercicios = await _tipoExerciciosRepositorio.UpdateTipoExercicios(tipoExerciciosModel, id);
            return Ok(tipoExercicios);
        }

        [HttpDelete("DeleteTipoExercicios/{id:int}")]
        public async Task<ActionResult<TipoExerciciosModel>> DeleteTipoExercicios(int id)
        {
            bool deleted = await _tipoExerciciosRepositorio.DeleteTipoExercicios(id);
            return Ok(deleted);
        }
    }
}
