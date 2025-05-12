using System.ComponentModel.DataAnnotations;

public class Author
{
    public int Id { get; set; }
    [Required]
    [MaxLength(250)]
    public string FullName { get; set; }
    [MaxLength(10)]
    public string AddressNo { get; set; }
    [MaxLength(200)]
    public string Street { get; set; }
    [Required]
    [MaxLength(50)]
    public string City { get; set; }
    [Required]
    [MaxLength(50)]
    public string JobRole { get; set; }
    public ICollection<Todo> Todos { get; set; } = new List<Todo>();

}