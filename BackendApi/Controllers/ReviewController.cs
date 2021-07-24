

using BackendApi.Context;
using BackendApi.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ReviewController : Controller
    {
        private readonly DataContext _context;
        public ReviewController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ReviewModel>>> GetUsers()
        {
            return await _context.Review.ToListAsync();
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPrivate")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<ReviewModel>>> GetUsersPrivate()
        {
            return await _context.Review.ToListAsync();
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPrivate-scoped")]
        [Authorize("read:messages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<ReviewModel>>> GetUsersPrivateScoped()
        {
            return await _context.Review.ToListAsync();
        }


    }
}
