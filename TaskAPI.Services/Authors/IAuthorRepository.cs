public interface IAuthorRepository
{
   public List<Author> GetAllAuthors();
   public Author GetAuthor(int id);
   public List<Author> GetAllAuthors(string job, string search);
   public Author AddAuthor(Author author);
}