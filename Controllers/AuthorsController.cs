using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var author = _service.GetById(id);
        return author == null ? NotFound() : Ok(author);
    }

    [HttpPost]
    public IActionResult Create(Author author)
    {
        var created = _service.Add(author);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Author author)
    {
        if (id != author.Id) return BadRequest("ID mismatch");

        var updated = _service.Update(author);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}