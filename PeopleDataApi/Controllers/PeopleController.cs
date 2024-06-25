using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleDataApi.Data;
using PeopleDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleContext _context;

        public PeopleController(PeopleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            var existingPerson = await _context.People.FindAsync(person.NumberId);
            if (existingPerson != null)
            {
                return Conflict(new { message = "A person with this ID already exists." });
            }

            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPeople), new { id = person.NumberId }, person);
        }

        [HttpDelete("{numberId}")]
        public async Task<IActionResult> DeletePerson(int numberId)
        {
            var person = await _context.People.FindAsync(numberId);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
