using Assignment_Eshmeeta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Assignment_Eshmeeta.Controllers
{
    [Route("/api/tasks")]
    [ApiController]
    public class RetrieveAll : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public RetrieveAll(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        //To retrieve all tasks from the database
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _appDbContext.Tasks.ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        //To add a new task to the database
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Tasks newTask)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
               

                var additionalTask = new Tasks
                {
                   // Id = newTask.Id,
                    Title = newTask.Title,
                    Description = newTask.Description,
                    Status = newTask.Status,
                };

                _appDbContext.Tasks.Add(additionalTask);
                await _appDbContext.SaveChangesAsync();

                // Return a 201 Created response 
                return StatusCode(201, newTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Tasks tasktodo)
        {
            if(id != tasktodo.Id)
            {
                //id in url does not match task id
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingtask = await _appDbContext.Tasks.FindAsync(id);
                if(existingtask == null)
                {
                    return NotFound();
                }

                //update
                _appDbContext.Entry(existingtask).CurrentValues.SetValues(tasktodo);

                //mark as modified
                _appDbContext.Entry(existingtask).State = EntityState.Modified;

                await _appDbContext.SaveChangesAsync();
                return NoContent();

            }
            catch(DbUpdateConcurrencyException ex)
            {
                return StatusCode(409);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }


        }


        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                // Check if the task with the specified ID exists
                var taskToDelete = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToDelete == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }

                // Delete the task from the database
                _appDbContext.Tasks.Remove(taskToDelete);
                _appDbContext.SaveChanges();

                // Return a success response
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also customize the response based on the type of exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
