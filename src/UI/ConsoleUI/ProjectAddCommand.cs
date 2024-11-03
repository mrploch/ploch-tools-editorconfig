using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Ploch.Common.CommandLine;
using Ploch.EditorConfigTools.UseCases;

namespace Ploch.EditorConfigTools.UI.ConsoleUI;

[Command(Name = "add", Description = "Add a new project")]
public class ProjectAddCommand(ProjectCommand parent, AddNewOrUpdateProject addNewOrUpdateProject) : IAsyncCommand
{
    [Option(CommandOptionType.SingleValue, Description = "The description of the project", ShortName = "d", LongName = "description",
            Inherited = true)]
    public string? ProjectDescription { get; set; }

    [Option(CommandOptionType.SingleValue, Description = "The path to the project", ShortName = "p", LongName = "path", Inherited = true)]
    [Required]
    public string ProjectPath { get; set; } = null!;

    public async Task OnExecuteAsync(CancellationToken cancellationToken = default)
    {
        await addNewOrUpdateProject.ExecuteAsync(new AddNewOrUpdateProjectSettings(parent.ProjectName, ProjectDescription, ProjectPath));
    }
}
