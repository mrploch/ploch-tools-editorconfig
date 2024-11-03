using Microsoft.Extensions.DependencyInjection;

namespace Ploch.EditorConfigTools.UseCases;
public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddUseCases(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<AddEditorConfigFile>()
                                .AddScoped<AddNewOrUpdateProject>();
    }
}