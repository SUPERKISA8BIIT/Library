using Library.BLL.DTOs.AddDto;
using Library.BLL.DTOs.UpdateDto;
using Library.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/book")]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var books = await _bookService.GetBooksAsync();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        return Ok(book);
    }

    [HttpGet("GetByISBN/{ISBN}")]
    public async Task<IActionResult> GetByISBNAsync([FromRoute] string ISBN)
    {
        var book = await _bookService.GetBookByISBN(ISBN);

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddBookDto book)
    {
        var id = await _bookService.AddBookAsync(book);

        return Created($"{HttpContext.Request.Path}", id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _bookService.DeleteBookAsync(id);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateBookDto book)
    {
        await _bookService.UpdateBookAsync(book, id);

        return Ok(book);
    }
}
