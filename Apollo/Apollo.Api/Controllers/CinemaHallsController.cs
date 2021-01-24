﻿using Apollo.Core.Interface.Services;
using Apollo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        public CinemasController(ICinemaHallService logic)
        {
            Logic = logic;
        }

        private ICinemaHallService Logic { get; }

        [HttpGet]
        public async Task<IEnumerable<CinemaHall>> GetAll()
        {
            return await Logic.GetAllCinemaHalls();
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CinemaHall data)
        {
            if (await Logic.CinemaHallExists(data))
            {
                return Conflict();
            }

            await Logic.Insert(data);
            return new ObjectResult(data) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CinemaHall data)
        {
            if (!await Logic.CinemaHallExists(data))
            {
                return NotFound();
            }

            await Logic.Delete(data);
            await Logic.Insert(data);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] CinemaHall data)
        {
            if (!await Logic.CinemaHallExists(data))
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