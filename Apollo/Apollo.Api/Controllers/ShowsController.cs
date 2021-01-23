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
    public class ShowsController : ControllerBase
    {
        public ShowsController(IShowService logic)
        {
            Logic = logic;
        }

        private IShowService Logic { get; }

        [HttpGet]
        public async Task<IEnumerable<Show>> GetAll()
        {
            return await Logic.GetAllShows();
        }

        [HttpGet("{date}/{hall}/{movie}")]
        public async Task<IActionResult> GetCapacity(string date, string hall, string movie)
        {
            return new JsonResult($"{date}, {hall}, {movie}");
        }

        
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Show data)
        {
            if (await Logic.ShowExists(data))
            {
                return Conflict();
            }

            await Logic.Insert(data);
            Show createdShow = new Show(data.StartsAt, data.Movie, data.CinemaHall);
            return new ObjectResult(createdShow) { StatusCode = StatusCodes.Status201Created };
        }
        
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Show data)
        {
            if (!await Logic.ShowExists(data))
            {
                return NotFound();
            }

            await Logic.Delete(data);
            return NoContent();
        }
    }
}
