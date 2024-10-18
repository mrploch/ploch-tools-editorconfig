using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Ploch.Common.CommandLine;

namespace Ploch.EditorConfigTools.UI.ConsoleUI;

[Command(Name = "project", Description = "Manage .editorconfig projects")]
public class ProjectCommand(CommandLineApplication app) : HelpOnlyCommand(app)
{
    [Option(CommandOptionType.SingleValue, Description = "The name of the project", ShortName = "n", LongName = "name", Inherited = true)]
    [Required]
    public string ProjectName { get; set; } = null!;
}