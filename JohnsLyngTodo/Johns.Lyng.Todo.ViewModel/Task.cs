using System.ComponentModel.DataAnnotations;

namespace Johns.Lyng.Todo.ViewModel
{
    public class Task
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
