public interface ITodoRepository
{
    public List<Todo> GetAllTodos(int authorId); // This method returns a list of todos for a specific author
    public Todo GetTodo(int authorId, int id);
    public Todo AddTodo(int authorId, Todo todo);
    public void UpdateTodo(Todo todo);
    public void DeleteTodo(Todo todo);
}