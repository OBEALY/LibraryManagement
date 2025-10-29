using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var book = _service.GetById(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        var created = _service.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id) return BadRequest("ID mismatch");

        var updated = _service.Update(book);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}