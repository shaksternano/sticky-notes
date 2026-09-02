using Microsoft.EntityFrameworkCore;
using StickyNotes.API.Models;

namespace StickyNotes.API.Data;

public class StickyNotesDbContext(DbContextOptions<StickyNotesDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes => Set<Note>();
}
