using Apollo.Core.Interface.Services;
using Apollo.Domain;
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

        [HttpGet]
        public async Task<IActionResult> GetCapacity(string date, string hall, string movie)
        {
            return new JsonResult("34");
        }

        
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Show data)
        {
            if (await Logic.ShowExists(data))
            {
                return Conflict();
            }

            await Logic.Insert(data);
            return CreatedAtAction("GetShow", new { startsAt = data.StartsAt, movie = data.Movie, cinemaHall = data.CinemaHall }, data);
        }
        /*
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Show data)
        {

        }*/
    }
}
