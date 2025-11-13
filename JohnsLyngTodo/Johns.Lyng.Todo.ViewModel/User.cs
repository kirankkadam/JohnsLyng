using Johns.Lyng.Todo.Model.Interfaces;

namespace Johns.Lyng.Todo.ViewModel
{
    public class User: IViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
