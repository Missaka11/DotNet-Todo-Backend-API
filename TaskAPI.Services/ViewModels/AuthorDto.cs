// This AuthorDto class, Data Transfer Object (DTO) used to transfer author data between layers of the application.
// This is for give data to the outside.
public class AuthorDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string JobRole { get; set; }
}