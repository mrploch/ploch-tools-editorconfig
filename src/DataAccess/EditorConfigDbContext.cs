#region

using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Ploch.EditorConfigTools.Models;

#endregion

#pragma warning disable CS8618

namespace Ploch.EditorConfigTools.DataAccess;

public class EditorConfigDbContext : IdentityDbContext<ApplicationUser> /*ApiAuthorizationDbContext<ApplicationUser>*/
{
    public EditorConfigDbContext(DbContextOptions<EditorConfigDbContext> options /*, IOptions<OperationalStoreOptions> operationalStoreOptions*/) :
        base(options/* , operationalStoreOptions*/)
    { }

    /*public EditorConfigDbContext(DbContextOptions<EditorConfigDbContext> options/*, Action<DbContextOptionsBuilder> configureDbContext#1#/*#1#) : base(options,
        new SimpleOptions<OperationalStoreOptions>(new OperationalStoreOptions { ConfigureDbContext = configureDbContext }))
    { }*/

    public DbSet<Project>? Projects { get; set; }

    public DbSet<EditorConfigFile> EditorConfigFiles { get; set; }

    public DbSet<ConfigSection> ConfigSections { get; set; }

    public DbSet<ConfigSectionType> ConfigSectionTypes { get; set; }

    public DbSet<FileExtension> FileExtensions { get; set; }

    public DbSet<ConfigEntry> ConfigEntries { get; set; }

    public DbSet<ValueDefinition> ValueDefinitions { get; set; }

    public DbSet<ValueType> ValueTypes { get; set; }

    public DbSet<SettingDefinition> SettingDefinitions { get; set; }

    public DbSet<SettingCategory> SettingCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseLazyLoadingProxies();
        base.OnConfiguring(options);
    }
}