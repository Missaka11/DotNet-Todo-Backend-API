public class CreateTodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Due { get; set; }
    public TodoStatus Status { get; set; }
}