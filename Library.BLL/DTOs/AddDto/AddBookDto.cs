
namespace Library.BLL.DTOs.AddDto;

public class AddBookDto
{
    public string ISBN { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}
