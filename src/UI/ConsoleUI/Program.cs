using Ploch.Data.EFCore;
using Ploch.Common.CommandLine;
using Ploch.Data.EFCore.SqlServer;
using Ploch.Common.CommandLine.Serilog;
using Ploch.EditorConfigTools.UseCases;
using Ploch.EditorConfigTools.DataAccess;
using Ploch.EditorConfigTools.Processing;
using Ploch.Data.GenericRepository.EFCore;
using Ploch.EditorConfigTools.UI.ConsoleUI;
using Microsoft.Extensions.DependencyInjection;

await AppBuilder
      .CreateDefault(new CommandAppProperties(".editorconfig File Tools", "Application providing tools for working with .editorconfig files"))
      .Configure(container =>
                 {
                     container.Services
                              .AddDbContext<EditorConfigDbContext>(context =>
                                                                       new SqlServerDbContextConfigurator(ConnectionString.FromJsonFile()() ??
                                                                                                          throw new
                                                                                                              InvalidOperationException("Connection string was not found"))
                                                                           .Configure(context))
                              .AddRepositories<EditorConfigDbContext>()
                              .AddProcessing()
                              .AddUseCases();

                     container.Application.Command<ProjectCommand>(command => command.Command<ProjectAddCommand>());
                 })
      .UseSerilog()
      .Build()
      .ExecuteAsync(args);