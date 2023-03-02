using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodolistNg;
using TodolistNg.Data;

namespace TodolistNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypesControllers : ControllerBase
    {
        private readonly DataContext _context;

        public TaskTypesControllers(DataContext context)
        {
            _context = context;
        }

        // GET: api/TaskTypesControllers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskType>>> GetTaskTypes()
        {
          if (_context.TaskTypes == null)
          {
              return NotFound();
          }
            return await _context.TaskTypes.ToListAsync();
        }

        // GET: api/TaskTypesControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskType>> GetTaskType(int id)
        {
          if (_context.TaskTypes == null)
          {
              return NotFound();
          }
            var taskType = await _context.TaskTypes.FindAsync(id);

            if (taskType == null)
            {
                return NotFound();
            }

            return taskType;
        }

        // PUT: api/TaskTypesControllers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskType(int id, TaskType taskType)
        {
            if (id != taskType.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTypeExists(id))
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

        // POST: api/TaskTypesControllers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskType>> PostTaskType(TaskType taskType)
        {
          if (_context.TaskTypes == null)
          {
              return Problem("Entity set 'DataContext.TaskTypes'  is null.");
          }
            _context.TaskTypes.Add(taskType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskType", new { id = taskType.Id }, taskType);
        }

        // DELETE: api/TaskTypesControllers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskType(int id)
        {
            if (_context.TaskTypes == null)
            {
                return NotFound();
            }
            var taskType = await _context.TaskTypes.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            _context.TaskTypes.Remove(taskType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskTypeExists(int id)
        {
            return (_context.TaskTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
