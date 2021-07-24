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
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        /// <summary>
        /// Get a user by his Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var todoItem = await _context.User.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="id">long id of entities</param>
        /// <param name="todoItem">object to update</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItem(int id, UserModel item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an entities by Id
        /// </summary>
        /// <param name="id">long id of entities</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            var todoItem = await _context.User.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.User.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }



        private bool ItemExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
