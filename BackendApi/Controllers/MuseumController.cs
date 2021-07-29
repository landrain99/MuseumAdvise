using BackendApi.Context;
using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class MuseumController : Controller
    {

        private readonly DataContext _context;
        public MuseumController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Museum
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllMuseum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MuseumModel>>> GetReview()
        {
            return await _context.Museum.ToListAsync();
        }

        /// <summary>
        /// Get all Museum
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMuseumById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMuseumByID(int id)
        {
            try
            {
                var museum = _context.Museum.Where(x => x.Id == id).FirstOrDefault();
                return Ok(museum);
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}
