using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Synonyms.Models;

namespace Synonyms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordsContext _context;

        public WordsController(WordsContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public IEnumerable<Words> GetWords()
        {
            return _context.Words;
        }

        

        // PUT: api/Words/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWords([FromRoute] int id, [FromBody] Words words)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != words.id)
            {
                return BadRequest();
            }

            _context.Entry(words).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordsExists(id))
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

        // POST: api/Words
        [HttpPost]
        public async Task<IActionResult> PostWords([FromBody] Words words)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Words.Add(words);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWords", new { id = words.id }, words);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWords([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var words = await _context.Words.FindAsync(id);
            if (words == null)
            {
                return NotFound();
            }

            _context.Words.Remove(words);
            await _context.SaveChangesAsync();

            return Ok(words);
        }

        private bool WordsExists(int id)
        {
            return _context.Words.Any(e => e.id == id);
        }
    }
}