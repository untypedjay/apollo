using Apollo.Core.Interface.Services;
using Apollo.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Api.Controllers
{
    public class ShowsController : Controller
    {
        public ShowsController(IShowService logic)
        {
            Logic = logic;
        }

        private IShowService Logic { get; }

        [HttpGet]
        public async Task<IEnumerable<Show>> GetAll()
        {
            return await Logic.GetShowsToday();
        }
    }
}
