namespace Ploch.EditorConfigTools.UI.WebUI.Models;

public record EditorConfigFileModel(int Id, string Name, string FilePath, string? Description, bool IsRoot, string FileHash, int ProjectId);
