using AutoMapper;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<Todo, TodosDto>(); // All the properties are same in both classes. So no need to specify the mapping
        CreateMap<CreateTodoDto, Todo>();
        CreateMap<UpdateTodoDto, Todo>();
    }
}