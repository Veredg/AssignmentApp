
using System.Collections.Generic;

using System.Threading.Tasks;
using AssignmenApp.API.BLL.IBLL;
using AssignmenApp.API.Entities;
using AssignmenApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IsraeliProduct.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : Controller
    {
        
        private readonly ITaskBll _taskBLL;

        public TaskController(ITaskBll taskBLL)
            
        {

            _taskBLL = taskBLL;
        }
        [HttpPost("GetTaksListAsync")]
        public async Task<IActionResult> GetTaskListAsync([FromBody] string Email)
        {
            if (!_taskBLL.EmailIsValid(Email)) {
               return BadRequest("Email is not valid");
            }
            else {
                IEnumerable<MyTask> TaskList = await _taskBLL.GetTasksListAsync(Email);
                if (TaskList == null)
            {
                return NoContent();

            }
            return Ok(TaskList);
            } 
            
        }
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTaskAsync(TaskForUpdateDto task)
        {
            if (await _taskBLL.UpdateTaskAsync(task))
                return Ok(true);

            return BadRequest();

        }
        [HttpPost("InsertTask")]
        public async Task<IActionResult> InsertTaskAsync( TaskForUserDto task)
        {
            if (await _taskBLL.InsertTaskAsync(task))
                return Ok(true);

            return BadRequest();

        }

         [HttpDelete("RemoveTask")]
        public async Task<IActionResult> RemoveTaskAsync(int Id)
        {
            if (await _taskBLL.RemoveTaskAsync(Id))
                return Ok(true);

            return BadRequest();

        }

    }
}
