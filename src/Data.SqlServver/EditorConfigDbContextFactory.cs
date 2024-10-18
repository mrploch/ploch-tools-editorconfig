using Microsoft.EntityFrameworkCore;
using Ploch.Data.EFCore;
using Ploch.Data.EFCore.IdentityServer.SqlServer;
using Ploch.Data.EFCore.SqlServer;
using Ploch.EditorConfigTools.DataAccess;

namespace Ploch.GroupMatters.Data.SqlServer;

// public class EditorConfigDbContextFactory : SqlServerDbContextFactory<EditorConfigDbContext, EditorConfigDbContextFactory>
// {
    // public EditorConfigDbContextFactory() : base(options =>
        // new EditorConfigDbContext(options, new SqlServerOperationalStoreOptionsFactory(ApplyMigrationsAssembly).Create()))
    // { }


    /*
     * public EditorConfigDbContextFactory() : base(options => new EditorConfigDbContext(options,
        new SimpleOptions<OperationalStoreOptions>(new OperationalStoreOptions { ConfigureDbContext = ConfigureDbContextAction(ConnectionString.FromJsonFile()) })))
    { }
     */

public class EditorConfigDbContextFactory : BaseDbContextFactory<EditorConfigDbContext, EditorConfigDbContextFactory>
{
    public EditorConfigDbContextFactory() : base(options => new EditorConfigDbContext(options))
    { }

    protected override DbContextOptionsBuilder<EditorConfigDbContext> ConfigureOptions(Func<string> connectionStringFunc,
        DbContextOptionsBuilder<EditorConfigDbContext> optionsBuilder)
    {
        return optionsBuilder.UseSqlServer(connectionStringFunc(), ApplyMigrationsAssembly);
    }
}