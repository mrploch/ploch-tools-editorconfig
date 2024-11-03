using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.UI.WebUI.Models;
public static class ModelsExtensions
{
    public static EditorConfigFileModel ToModel(this EditorConfigFile editorConfigFile)
    {
        return new EditorConfigFileModel(editorConfigFile.Id,
                                         editorConfigFile.Name,
                                         editorConfigFile.FilePath,
                                         editorConfigFile.Description,
                                         editorConfigFile.IsRoot,
                                         editorConfigFile.FileHash,
                                         editorConfigFile.Project.Id);
    }

    public static void UpdateDataModel(this EditorConfigFileModel viewModel, EditorConfigFile dataModel)
    {
        dataModel.Name = viewModel.Name;
        dataModel.FilePath = viewModel.FilePath;
        dataModel.Description = viewModel.Description;
        dataModel.IsRoot = viewModel.IsRoot;
        dataModel.FileHash = viewModel.FileHash;
    }

    public static ConfigEntryModel ToModel(this ConfigEntry configEntry)
    {
        return new ConfigEntryModel(configEntry.Name!, configEntry.Value, configEntry.ConfigSection!.GlobPattern,
                                    configEntry.Comments?.Select(c => c.Value) ?? [], string.Join(", ", configEntry.Comments.Select(c => c.Value)));
    }
}
