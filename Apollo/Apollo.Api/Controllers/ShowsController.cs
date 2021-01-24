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

        [HttpGet("capacity")]
        public async Task<IActionResult> GetCapacity([FromBody] Show data)
        {
            return Ok(await Logic.GetCapacityByShow(data));
        }

        
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Show data)
        {
            if (await Logic.ShowExists(data))
            {
                return Conflict();
            }

            await Logic.Insert(data);
            
            return new ObjectResult(data) { StatusCode = StatusCodes.Status201Created };
        }
        
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Show data)
        {
            if (!await Logic.ShowExists(data))
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
