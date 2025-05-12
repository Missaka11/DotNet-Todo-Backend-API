using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

[ApiController]
[Route("api/authors")] //This will be the base route for this controller. It gets from ("Task"Controller)
public class AuthorsController : ControllerBase
{
    private readonly IAuthorRepository _service; //This is how we import the TodoService class and this is a best practice
    private readonly IMapper _mapper; //This is how we import the TodoService class and this is a best practice
    public AuthorsController(IAuthorRepository service, IMapper mapper)
    {
        _service = service; //This is how we create an instance of the TodoService class to get access to the AllTodos() method
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<ICollection<AuthorDto>> GetAllAuthors(string? job = null, string? search = null)
    {
        // throw new Exception("This is a test exception"); // This is a test exception to see if the error handling middleware works
        var authors = _service.GetAllAuthors(job, search);
        // var authorsDto = new List<AuthorDto>();

        var mappedAuthors = _mapper.Map<ICollection<AuthorDto>>(authors); //Tell to get ICollection because it returns list

        // This method is no longer needed because we are using AutoMapper. This code snoppet is for view only
        // foreach (var author in authors)
        // {
        //     authorsDto.Add(new AuthorDto
        //     {
        //         Id = author.Id,
        //         FullName = author.FullName,
        //         Address = $"{author.AddressNo}, {author.Street}, {author.City}"
        //     });
        // }

        return Ok(mappedAuthors);
    }
    [HttpGet("{id}", Name = "GetAuthor")]
    public IActionResult GetAuthor(int id)
    {
        var author = _service.GetAuthor(id);
        var mappedAuthor = _mapper.Map<AuthorDto>(author); // This does not returns a list, it returns a single object so ICollection is not needed

        // If author is not found, return a 404 Not Found response
        if (author is null)
        {
            return NotFound();
        }

        return Ok(mappedAuthor);
    }

    [HttpPost]
    public ActionResult<AuthorDto> CreateAuthor(CreateAuthorDto author)
    {
        var authorEntity = _mapper.Map<Author>(author);
        var newAuthor = _service.AddAuthor(authorEntity);

        // For return the created author
        var authorForReturn = _mapper.Map<AuthorDto>(newAuthor);
        return CreatedAtRoute("GetAuthor", new { id = authorForReturn.Id }, authorForReturn);
    }
}