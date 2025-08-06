using Microsoft.AspNetCore.Mvc;
using FlashcardApi.Models;
using FlashcardApi.Services;

namespace FlashcardApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashcardsController : ControllerBase
{
    private readonly FlashcardRepository _repo;

    public FlashcardsController(FlashcardRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FlashcardSet>> GetAll() =>
        Ok(_repo.GetAll());

    [HttpGet("{id}")]
    public ActionResult<FlashcardSet> GetById(string id)
    {
        var set = _repo.GetById(id);
        return set is not null ? Ok(set) : NotFound();
    }

    [HttpPost]
    public ActionResult<FlashcardSet> Add([FromBody] FlashcardSet input)
    {
        var created = _repo.Add(input.Title);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] FlashcardSet input)
    {
        if (id != input.Id) return BadRequest();
        var success = _repo.Update(input);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var success = _repo.Delete(id);
        return success ? NoContent() : NotFound();
    }
}
