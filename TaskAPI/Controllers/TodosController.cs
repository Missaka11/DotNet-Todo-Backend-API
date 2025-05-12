using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/authors/{authorId}/todos")] //This will be the base route for this controller. It gets from ("Task"Controller)
public class TodosController : ControllerBase
{
    private readonly ITodoRepository _todoService; //This is how we import the TodoService class and this is a best practice
    private readonly IMapper _mapper; //This is how we import the TodoService class and this is a best practice
    public TodosController(ITodoRepository repository, IMapper mapper)
    {
        _todoService = repository; //This is how we create an instance of the TodoService class to get access to the AllTodos() method
        _mapper = mapper;
    }

    // This endpoint do both returning all todos and a specific todo
    [HttpGet]
    public ActionResult<ICollection<TodosDto>> GetTodos(int authorId)
    {
        var myTodos = _todoService.GetAllTodos(authorId); // This method returns a list of todos for a specific author
        var mappedTodos = _mapper.Map<ICollection<TodosDto>>(myTodos); //Tell to get ICollection because it returns list
        return Ok(mappedTodos);
    }

    [HttpGet("{id}", Name = "GetTodo")]
    public IActionResult GetOneTodo(int authorId, int id)
    {
        var todo = _todoService.GetTodo(authorId, id);

        // If todo is not found, return a 404 Not Found response
        if (todo is null)
        {
            return NotFound();
        }
        var mappedTodos = _mapper.Map<TodosDto>(todo); // This does not returns a list, it returns a single object so ICollection is not needed

        return Ok(mappedTodos);
    }

    [HttpPost]
    public ActionResult<TodosDto> CreateTodo(int authorId, CreateTodoDto todo)
    {
        var todoEntity = _mapper.Map<Todo>(todo);
        var newTodo = _todoService.AddTodo(authorId, todoEntity);
        var todoForReturn = _mapper.Map<TodosDto>(newTodo);

        return CreatedAtRoute("GetTodo", new { authorId, id = todoForReturn.Id }, todoForReturn);
    }

    [HttpPut("{todoId}")]
    public ActionResult UpdateTodo(int authorId, int todoId, UpdateTodoDto todo)
    {
        var updatingTodo = _todoService.GetTodo(authorId, todoId);
        if (updatingTodo is null)
        {
            return NotFound();
        }

        _mapper.Map(todo, updatingTodo); // This will map the properties of the todo object to the updatingTodo object
        _todoService.UpdateTodo(updatingTodo); // This will update the todo object in the database
        return Ok();
    }

    [HttpDelete("{todoId}")]
    public ActionResult DeleteTodo(int authorId, int todoId)
    {
        var deletingTodo = _todoService.GetTodo(authorId, todoId);
        if (deletingTodo is null)
        {
            return NotFound();
        }
        _todoService.DeleteTodo(deletingTodo); // This will delete the todo object from the database
        return NoContent(); // This will return a 204 No Content response
    }

}
