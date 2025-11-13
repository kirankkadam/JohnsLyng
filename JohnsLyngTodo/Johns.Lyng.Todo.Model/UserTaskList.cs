using Johns.Lyng.Todo.Model.Interfaces;

namespace Johns.Lyng.Todo.Model
{
    public class UserTaskList: IModel
    {
        public UserTaskList() { 
            Tasks = new List<UserTask>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int OwnerId { get; set; }
        public int Status { get; set; }
        public List<UserTask>? Tasks { get; set; }
    }
}
