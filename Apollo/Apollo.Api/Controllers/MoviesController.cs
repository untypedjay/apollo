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
            Movie createdMovie = new Movie(data.Title, data.Description, data.Genre, data.Length, data.Actors, data.ImageURL, data.TrailerURL);
            return new ObjectResult(createdMovie) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Movie data)
        {
            if (!await Logic.MovieExists(data))
            {
                return NotFound();
            }

            await Logic.Delete(data);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Movie data)
        {
            if (!await Logic.MovieExists(data))
            {
                return NotFound();
            }

            await Logic.Delete(data);
            await Logic.Insert(data);
            return NoContent();
        }
    }
}
