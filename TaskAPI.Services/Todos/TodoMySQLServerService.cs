using TaskAPI.DataAccess;

public class TodoMySQLServerService : ITodoRepository
{
    private readonly TodoDBContext _context = new TodoDBContext();
    public List<Todo> GetAllTodos(int authorId)
    {
        // return _context.Todos.ToList();
        return _context.Todos.Where(t => t.AuthorId == authorId).ToList(); // This method returns a list of todos for a specific author
    }

    public Todo GetTodo(int authorId, int id)
    {
        return _context.Todos.FirstOrDefault(t => t.Id == id && t.AuthorId == authorId); // This method returns a single todo for a specific author
    }

    public Todo AddTodo(int authorId, Todo todo)
    {
        todo.AuthorId = authorId;
        _context.Todos.Add(todo);
        _context.SaveChanges();

        return (_context.Todos.Find(todo.Id));
    }

    public void UpdateTodo(Todo todo)
    {
        _context.SaveChanges();
    }

    public void DeleteTodo(Todo todo)
    {
        _context.Remove(todo);
        _context.SaveChanges();
    }
}