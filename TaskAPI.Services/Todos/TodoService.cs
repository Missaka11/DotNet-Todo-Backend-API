// public class TodoService : ITodoRepository
// {
//     public List<Todo> GetAllTodos()
//     {
//         var todos = new List<Todo>();

//         var todo1 = new Todo
//         {
//             Id = 0,
//             Title = "Get books for school",
//             Description = "Get some text books for school",
//             Created = DateTime.Now,
//             Due = DateTime.Now.AddDays(7),
//             Status = TodoStatus.New
//         };
//         todos.Add(todo1);

//         var todo2 = new Todo
//         {
//             Id = 1,
//             Title = "Get vegetables",
//             Description = "Get some vegitables for the week",
//             Created = DateTime.Now,
//             Due = DateTime.Now.AddDays(5),
//             Status = TodoStatus.Completed
//         };
//         todos.Add(todo2);

//         var todo3 = new Todo
//         {
//             Id = 2,
//             Title = "Get fruits",
//             Description = "Get some fruits for the week",
//             Created = DateTime.Now,
//             Due = DateTime.Now.AddDays(10),
//             Status = TodoStatus.New
//         };
//         todos.Add(todo3);

//         return todos;
//     }
// }