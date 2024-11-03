using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Ploch.EditorConfigTools.Processing;
public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddProcessing(this IServiceCollection services)
    {
        return services.AddScoped<ProjectPathProcessor>()
                       .AddScoped<EditorConfigFileProcessor>()
                       .AddScoped<SectionProcessor>()
                       .AddScoped<ConfigEntryProcessor>()
                       .AddScoped<SettingDefinitionFactory>()
                       .AddScoped<ProcessingContext>()
                       .AddScoped<IFileSystem, FileSystem>();
    }
}
