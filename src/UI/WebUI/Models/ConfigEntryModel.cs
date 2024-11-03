namespace Ploch.EditorConfigTools.UI.WebUI.Models;

public record ConfigEntryModel(string Name, string? Value, string? ConfigSectionGlob, IEnumerable<string>? Comments, string JoinedComments);
