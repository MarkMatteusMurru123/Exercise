using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exercise.Model;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExercisesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Exercise>>> GetExerciseList([FromQuery]ExerciseIntensity? intensity, [FromQuery] string? title, [FromQuery]  int? minimum, [FromQuery] int? maximum)
        {
            return await _context.ExerciseList.Where(x => x.Intensity == intensity || intensity == null)
                .Where(x => x.Title == title || title == null)
                .Where(x => x.RecommendedDurationInSeconds >= minimum || minimum == null)
                .Where(x => x.RecommendedDurationInSeconds <= maximum || maximum == null).ToListAsync();
            
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Exercise>> GetExercise(int id)
        {
            var exercise = await _context.ExerciseList.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return exercise;
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, Model.Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(exercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model.Exercise>> PostExercise(Model.Exercise exercise)
        {
            _context.ExerciseList.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _context.ExerciseList.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _context.ExerciseList.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseExists(int id)
        {
            return _context.ExerciseList.Any(e => e.Id == id);
        }
    }
}
