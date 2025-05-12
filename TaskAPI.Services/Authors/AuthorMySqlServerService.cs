using TaskAPI.DataAccess;

public class AuthorMySqlServerService : IAuthorRepository
{
    private readonly TodoDBContext _context = new TodoDBContext(); // This is how we create an instance of the TodoDBContext class to get access to the database
    public List<Author> GetAllAuthors()
    {
        // This method should return a list of all authors from the database.
        return _context.Authors.ToList();
    }

    public List<Author> GetAllAuthors(string job, string search)
    {
        if (string.IsNullOrWhiteSpace(job) && string.IsNullOrWhiteSpace(search)) // Filter by job
        {
            return GetAllAuthors();
        }

        // First need to implement the filter.
        // Then need to implement the search. Because It is easy to search after the filtered things.
        // If not, it cause to a performance issue.
        var authorColllection = _context.Authors as IQueryable<Author>;

        // Filter by job
        if (!string.IsNullOrWhiteSpace(job))
        {
            job = job.Trim();
            authorColllection = authorColllection.Where(a => a.JobRole == job);
        }

        // Search according to the full name or city
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();
            authorColllection = authorColllection.Where(a => a.FullName.Contains(search) || a.City.Contains(search));
        }

        // After the filter and search is done, we call to the database to get the data. 
        // If it not, it cause to a performance issue.
        return authorColllection.ToList();
    }

    public Author GetAuthor(int id)
    {
        // This method should return a specific author by ID from the database.
        return _context.Authors.Find(id);
    }

    // For create an author
    public Author AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();

        return _context.Authors.Find(author.Id);
    }
}