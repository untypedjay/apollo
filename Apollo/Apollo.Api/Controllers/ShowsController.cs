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

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Show data)
        {
            if (!await Logic.ShowExists(data))
            {
                return NotFound();
            }

            await Logic.Update(data);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Show data)
        {
            if (await Logic.CurrencyExistsAsync(data.Symbol))
            {
                return Conflict();
            }

            await Logic.InsertAsnyc(data);
            return CreatedAtAction(nameof(GetBySymbol), new { symbol = data.Symbol }, null);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Show data)
        {

        }
    }
}
