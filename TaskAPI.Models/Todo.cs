using System.ComponentModel.DataAnnotations;

public class Todo
{
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
    [Required]
    public DateTime Created { get; set; }
    [Required]
    public DateTime Due { get; set; }
    [Required]
    public TodoStatus Status { get; set; } // New, Inprogress, Completed
    public int AuthorId { get; set; } // Foreign key
    public Author Author { get; set; } // Navigation property
}