using System.ComponentModel.DataAnnotations;

namespace StickyNotes.API.Models;

public class Note
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();

    public string Text { get; set; } = string.Empty;

    [MaxLength(6)] public string Color { get; set; } = "ff0000";
}
