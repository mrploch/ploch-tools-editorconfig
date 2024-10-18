using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Ploch.Common.CommandLine;
using Ploch.Data.EFCore;
using Ploch.Data.EFCore.SqlServer;
using Ploch.Data.GenericRepository.EFCore;
using Ploch.EditorConfigTools.DataAccess;
using Ploch.EditorConfigTools.Processing;
using Ploch.EditorConfigTools.UI.ConsoleUI;
using Ploch.EditorConfigTools.UseCases;

await AppBuilder.CreateDefault(new CommandAppProperties(".editorconfig File Tools", "Application providing tools for working with .editorconfig files"))
    .Configure(container =>
    {
        container.Services
            .AddDbContext<EditorConfigDbContext>(context =>
                new SqlServerDbContextConfigurator(ConnectionString.FromJsonFile()() ?? throw new InvalidOperationException("Connection string was not found"))
                    .Configure(context))
            .AddRepositories<EditorConfigDbContext>()
            .AddSingleton<AddNewOrUpdateProject>()
            .AddSingleton<ProjectPathProcessor>()
            .AddSingleton<EditorConfigFileProcessor>()
            .AddSingleton<SectionProcessor>()
            .AddSingleton<ConfigEntryProcessor>()
            .AddSingleton<SettingDefinitionFactory>()
            .AddSingleton<ProcessingContext>()
            .AddSingleton<IFileSystem, FileSystem>();

        container.Application.Command<ProjectCommand>(command => command.Command<ProjectAddCommand>());
    })
    .Build()
    .ExecuteAsync(args);