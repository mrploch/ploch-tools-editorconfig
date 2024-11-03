namespace Ploch.EditorConfigTools.UseCases;

public record AddEditorConfigFileSettings(int ProjectId, string FileName, Stream FileStream);
