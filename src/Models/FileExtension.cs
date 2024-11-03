using Ploch.Data.Model;

namespace Ploch.EditorConfigTools.Models;

public class FileExtension : IHasId<string>, INamed, IHasDescription
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public virtual FileType FileType { get; set; } = null!;
}
