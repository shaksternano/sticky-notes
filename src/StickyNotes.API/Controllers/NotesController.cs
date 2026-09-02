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
        return Ok(await db.Notes
            .AsNoTracking()
            .OrderByDescending(note => note.Id)
            .ToListAsync(cancellationToken)
        );
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
            Text = request.Text,
            Color = request.Color
        };

        db.Notes.Add(note);
        await db.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Patch(
        Guid id,
        PatchNoteRequest request,
        CancellationToken cancellationToken
    )
    {
        var note = await db.Notes.SingleOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note is null) return NotFound();
        if (request.Text is null && request.Color is null) return BadRequest("At least one field must be provided.");

        if (request.Text is not null) note.Text = request.Text;
        if (request.Color is not null) note.Color = request.Color;

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

public sealed record CreateNoteRequest(
    string Text,
    string Color
);

public sealed record PatchNoteRequest(
    string? Text = null,
    string? Color = null
);
