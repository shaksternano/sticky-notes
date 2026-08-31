using Microsoft.AspNetCore.Mvc;
using StickyNotes.API.Models;

namespace StickyNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class NotesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Note>> Get()
    {
        return Ok(Array.Empty<Note>());
    }
}
