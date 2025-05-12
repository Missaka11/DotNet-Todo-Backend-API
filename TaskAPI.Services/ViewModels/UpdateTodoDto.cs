using System.ComponentModel.DataAnnotations;

public class UpdateTodoDto
{
    [Required(ErrorMessage = "You must provide a title")]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Due { get; set; }
    public TodoStatus Status { get; set; }
}