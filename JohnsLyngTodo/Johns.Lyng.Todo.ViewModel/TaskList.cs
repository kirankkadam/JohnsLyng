using Johns.Lyng.Todo.Model.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Johns.Lyng.Todo.ViewModel
{
    public class TaskList: IViewModel
    {
        public TaskList()
        {
            Tasks = new List<Task>();
        }

        [Required]
        public int Id { get; set; }
        
        public string Title { get; set; }


        [Required]
        public int OwnerId { get; set; }

        public List<Task>? Tasks { get; set; }
    }
}
