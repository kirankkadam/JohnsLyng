using System.ComponentModel.DataAnnotations;

namespace Johns.Lyng.Todo.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
