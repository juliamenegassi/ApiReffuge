using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : ControllerBase
    {
        private readonly IExerciciosRepositorio _exerciciosRepositorio;

        public ExerciciosController(IExerciciosRepositorio exerciciosRepositorio)
        {
            _exerciciosRepositorio = exerciciosRepositorio;
        }

        [HttpGet("GetAllExercicio")]
        public async Task<ActionResult<List<ExerciciosModel>>> GetAllExercicio()
        {
            List<ExerciciosModel> exercicios = await _exerciciosRepositorio.GetAll();
            return Ok(exercicios);
        }

        [HttpGet("GetExerciciosId/{id}")]
        public async Task<ActionResult<ExerciciosModel>> GetExerciciosId(int id)
        {
            ExerciciosModel exercicios = await _exerciciosRepositorio.GetById(id);
            return Ok(exercicios);
        }

        [HttpPost("ExerciciosUser")]
        public async Task<ActionResult<ExerciciosModel>> InsertExercicios([FromBody] ExerciciosModel exerciciosModel)
        {
            ExerciciosModel exercicios = await _exerciciosRepositorio.InsertExercicios(exerciciosModel);
            return Ok(exercicios);
        }

        [HttpPut("UpdateExercicios/{id:int}")]
        public async Task<ActionResult<ExerciciosModel>> UpdateExercicios(int id, [FromBody] ExerciciosModel exerciciosModel)
        {
            exerciciosModel.ExerciciosId = id;
            ExerciciosModel exercicios = await _exerciciosRepositorio.UpdateExercicios(exerciciosModel, id);
            return Ok(exercicios);
        }

        [HttpDelete("DeleteExercicios/{id:int}")]
        public async Task<ActionResult<ExerciciosModel>> DeleteExercicios(int id)
        {
            bool deleted = await _exerciciosRepositorio.DeleteExercicios(id);
            return Ok(deleted);
        }
    }
}
