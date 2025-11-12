using Johns.Lyng.Todo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Johns.Lyng.Todo.Api.Controllers
{
    [ApiController]
    [Route("List")]
    public class ListController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetListForUser(int userId)
        {
            var taskListOfUser = DataStore.TaskLists.Where(tl => tl.OwnerId == userId).ToList();
            if (taskListOfUser.Count == 0)
            {
                return NoContent();
            }
            return Ok(taskListOfUser);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateList(TaskList taskList)
        {
            if (taskList == null)
            {
                return BadRequest();
            }

            DataStore.TaskLists.Add(new TaskList()
            {
                Id = taskList.Id,
                Title = taskList.Title,
                Description = taskList.Description,
                OwnerId = taskList.OwnerId,
                CreatedBy = taskList.CreatedBy,
                CreatedOn = DateTime.UtcNow
            });

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateList(TaskList taskList)
        {
            if (taskList == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteList(int listId)
        {
            if (listId == 0)
            {
                return BadRequest();
            }

            var item = DataStore.TaskLists.FirstOrDefault(tl=>tl.Id.Equals(listId));
            if (item == null)
            {
                return NoContent();
            }

            DataStore.TaskLists.Remove(item);
            return Ok();
        }
    }
}
