using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0414.Models
{
    // Create data table and columns
    public class SubmittedTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Sorry, you must input a task")]
        public string? TaskName { get; set; }
        public string? DueDate { get; set; }
        [Required(ErrorMessage = "Sorry, you must input a quadrant")]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? CategoryName { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
