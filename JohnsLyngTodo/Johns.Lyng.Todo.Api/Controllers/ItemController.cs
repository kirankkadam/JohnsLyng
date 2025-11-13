using Johns.Lyng.Todo.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Johns.Lyng.Todo.Api.Controllers
{
    [ApiController]
    [Route("Item")]
    public class ItemController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get(int listId, int taskId)
        {
            var taskList = DataStore.TaskLists.FirstOrDefault(tl => tl.Id == listId);
            if (taskList == null)
            {
                return BadRequest();
            }

            var item = taskList.Tasks.FirstOrDefault(i => i.Id == taskId);
            if (item == null)
            {
                return BadRequest();
            }

            var vmItem = Conversion.Instance.ConvertToViewModelTaskItem(item);
            return Ok(vmItem);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(int listId, ViewModel.Task item)
        {
            if (listId == 0 || item == null)
            {
                return BadRequest();
            }

            var list = DataStore.TaskLists.FirstOrDefault(tl => tl.Id == listId);
            if (list == null || list.Tasks == null)
            {
                return BadRequest();
            }

            item.Id = GetIdForTaskItemList(listId);
            list.Tasks.Add(Conversion.Instance.ConvertToModelTaskItem(item));
            var vmItem = Conversion.Instance.ConvertToViewModelTaskList(list);
            return Ok(vmItem);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(int listId, ViewModel.Task item)
        {
            if (listId == 0 || item == null)
            {
                return BadRequest();
            }

            var list = DataStore.TaskLists.FirstOrDefault(tl => tl.Id == listId);
            if (list == null || list.Tasks == null)
            {
                return BadRequest();
            }

            var listItem = list.Tasks.FirstOrDefault(i => i.Id == item.Id);
            if (listItem == null)
            {
                return BadRequest();
            }

            list.Tasks.Remove(listItem);
            list.Tasks.Add(Conversion.Instance.ConvertToModelTaskItem(item));
            var vmItem = Conversion.Instance.ConvertToViewModelTaskList(list);
            return Ok(vmItem);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int taskId, int listId)
        {
            var taskList = DataStore.TaskLists.FirstOrDefault(tl => tl.Id == listId);
            if (taskList == null)
            {
                return BadRequest();
            }

            var item = taskList.Tasks.FirstOrDefault(i => i.Id == taskId);
            if (item == null)
            {
                return BadRequest();
            }
            taskList.Tasks.Remove(item);
            var vmItem = Conversion.Instance.ConvertToViewModelTaskList(taskList);
            return Ok(vmItem);
        }

        private int GetIdForTaskItemList(int listId)
        {
            var id = 1;
            if (DataStore.TaskLists.Count > 0)
            {
                var list = DataStore.TaskLists.FirstOrDefault(tl => tl.Id == listId);
                if (list != null && list.Tasks != null)
                {
                    var maxId = list.Tasks.Select(l => l.Id).Max();
                    id = maxId + 1;
                }
            }

            return id;
        }
    }
}
