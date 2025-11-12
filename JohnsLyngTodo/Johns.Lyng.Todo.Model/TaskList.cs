using System.ComponentModel.DataAnnotations;

namespace Johns.Lyng.Todo.Model
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int OwnerId { get; set; }
        public int Status { get; set; }
        public List<Task>? Tasks { get; set; }
        public DateTime? CreatedOn { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
