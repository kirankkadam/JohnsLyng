using Johns.Lyng.Todo.Model.Interfaces;

namespace Johns.Lyng.Todo.Model
{
    public class User: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
