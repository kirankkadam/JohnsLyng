using Johns.Lyng.Todo.Model.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Johns.Lyng.Todo.ViewModel
{
    public class Task: IViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
