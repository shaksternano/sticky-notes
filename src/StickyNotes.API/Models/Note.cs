namespace StickyNotes.API.Models;

public class Note
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Content { get; set; } = string.Empty;
}
