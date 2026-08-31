using StickyNotes.API.Models;

namespace StickyNotes.API.Data;

using Microsoft.EntityFrameworkCore;

public class StickyNotesDbContext(DbContextOptions<StickyNotesDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes => Set<Note>();
}
