using Johns.Lyng.Todo.Model.Interfaces;

namespace Johns.Lyng.Todo.Model
{
    public class UserTask: IModel
    {
        public UserTask() { 
            Title = string.Empty;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
