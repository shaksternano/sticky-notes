using Microsoft.AspNetCore.Mvc;
using StickyNotes.API.Models;

namespace StickyNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class NotesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Note>> Get() => Ok(new[]
    {
        new Note(1, "Welcome to Sticky Notes!", "yellow"),
        new Note(2, "Replace this in-memory example with your persistence layer.", "blue")
    });
}
