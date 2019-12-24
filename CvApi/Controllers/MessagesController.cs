using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvApi.Models.Contexts;
using CvApi.Models.Entities;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly CVContext _context;

        public MessagesController(CVContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessageEntities()
        {
            return await _context.MessageEntities.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(long id)
        {
            var message = await _context.MessageEntities.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(long id, Message message)
        {
            if (id != message.MessageID)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.MessageEntities.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.MessageID }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> DeleteMessage(long id)
        {
            var message = await _context.MessageEntities.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.MessageEntities.Remove(message);
            await _context.SaveChangesAsync();

            return message;
        }

        private bool MessageExists(long id)
        {
            return _context.MessageEntities.Any(e => e.MessageID == id);
        }
    }
}
