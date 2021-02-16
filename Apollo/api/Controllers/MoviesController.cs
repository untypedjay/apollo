using Apollo.Core.Interface.Services;
using Apollo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesController(IMovieService logic)
        {
            Logic = logic;
        }

        private IMovieService Logic { get; }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await Logic.GetAllMovies();
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Movie data)
        {
            if (await Logic.MovieExists(data))
            {
                return Conflict();
            }

            await Logic.Insert(data);
            return new ObjectResult(data) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Movie data)
        {
            if (!await Logic.MovieExists(data))
            {
                return NotFound();
            }

            bool deleteSuccess = await Logic.Delete(data);
            bool insertSuccess = await Logic.Insert(data);

            if (deleteSuccess && insertSuccess)
            {
                return NoContent();
            }

            return new ObjectResult(data) { StatusCode = StatusCodes.Status403Forbidden };
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Movie data)
        {
            if (!await Logic.MovieExists(data))
            {
                return NotFound();
            }

            bool success = await Logic.Delete(data);
            if (success)
            {
                return NoContent();
            }

            return new ObjectResult(data) { StatusCode = StatusCodes.Status403Forbidden };
        }
    }
}