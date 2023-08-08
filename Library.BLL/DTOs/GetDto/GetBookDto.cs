
namespace Library.BLL.DTOs.GetDto;

public class GetBookDto
{
    public Guid Id { get; set; }
    public string ISBN { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
    public DateTime? TakingTime { get; set; }
    public DateTime? ReturningTime { get; set; }
}
