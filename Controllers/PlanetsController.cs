using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using planetsCSapi.Models;
using planetsCSapi.Services;

namespace planetsCSapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly PlanetsService _ps;

        public PlanetsController(PlanetsService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Planet>> GetAll()
        {
            try
            {
                return Ok(_ps.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
