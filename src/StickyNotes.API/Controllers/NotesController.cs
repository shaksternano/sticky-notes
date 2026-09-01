using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StickyNotes.API.Data;
using StickyNotes.API.Models;

namespace StickyNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class NotesController(StickyNotesDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> Get(CancellationToken cancellationToken)
    {
        return Ok(await db.Notes.AsNoTracking().ToListAsync(cancellationToken));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Note>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var note = await db.Notes
            .AsNoTracking()
            .SingleOrDefaultAsync(note => note.Id == id, cancellationToken);

        return note is null ? NotFound() : Ok(note);
    }

    [HttpPost]
    public async Task<ActionResult<Note>> Create(
        CreateNoteRequest request,
        CancellationToken cancellationToken
    )
    {
        var note = new Note
        {
            Content = request.Content
        };

        db.Notes.Add(note);
        await db.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateNoteRequest request,
        CancellationToken cancellationToken)
    {
        var note = await db.Notes.SingleOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note is null) return NotFound();

        note.Content = request.Content;
        await db.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var note = await db.Notes.SingleOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note is null) return NotFound();

        db.Notes.Remove(note);
        await db.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}

public sealed record CreateNoteRequest(string Content);

public sealed record UpdateNoteRequest(string Content);
