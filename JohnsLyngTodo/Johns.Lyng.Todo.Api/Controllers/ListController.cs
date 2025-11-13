using Johns.Lyng.Todo.Api.Helpers;
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
            if (taskListOfUser == null || taskListOfUser.Count == 0)
            {
                return NoContent();
            }

            var vmTaskLists = new List<ViewModel.TaskList>();
            foreach (var taskList in taskListOfUser)
            {
                vmTaskLists.Add(Conversion.Instance.ConvertToViewModelTaskList(taskList));
            }

            return Ok(vmTaskLists);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateList(ViewModel.TaskList taskList)
        {
            if (taskList == null)
            {
                return BadRequest();
            }

            taskList.Id = GetIdForTaskList();
            DataStore.TaskLists.Add(Conversion.Instance.ConvertToModelTaskList(taskList));
            var vmTaskLists = new List<ViewModel.TaskList>();
            foreach (var tl in DataStore.TaskLists)
            {
                vmTaskLists.Add(Conversion.Instance.ConvertToViewModelTaskList(tl));
            }

            return Ok(vmTaskLists);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateList(ViewModel.TaskList taskList)
        {
            if (taskList == null)
            {
                return BadRequest();
            }
            var item = DataStore.TaskLists.FirstOrDefault(tl => tl.Id.Equals(taskList.Id));
            if (item == null)
            {
                return NoContent();
            }

            DataStore.TaskLists.Remove(item);
            DataStore.TaskLists.Add(Conversion.Instance.ConvertToModelTaskList(taskList));

            var vmTaskLists = new List<ViewModel.TaskList>();
            foreach (var tl in DataStore.TaskLists)
            {
                vmTaskLists.Add(Conversion.Instance.ConvertToViewModelTaskList(tl));
            }

            return Ok(vmTaskLists);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteList(int listId)
        {
            if (listId == 0)
            {
                return BadRequest();
            }

            var item = DataStore.TaskLists.FirstOrDefault(tl => tl.Id.Equals(listId));
            if (item == null)
            {
                return NoContent();
            }

            DataStore.TaskLists.Remove(item);
            var vmTaskLists = new List<ViewModel.TaskList>();
            foreach (var tl in DataStore.TaskLists)
            {
                vmTaskLists.Add(Conversion.Instance.ConvertToViewModelTaskList(tl));
            }

            return Ok(vmTaskLists);
        }

        private int GetIdForTaskList()
        {
            var id = 1;
            if (DataStore.TaskLists.Count > 0)
            {
                var maxId = DataStore.TaskLists.Select(tl => tl.Id).Max();
                id = maxId + 1;
            }

            return id;
        }
    }
}
