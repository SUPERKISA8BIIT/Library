
namespace Library.DAL.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime TakingTime { get; set; }
    public DateTime ReturningTime { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

}
