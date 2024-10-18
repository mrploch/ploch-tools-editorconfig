using Ploch.Data.EFCore.SqLite;
using Ploch.EditorConfigTools.DataAccess;

namespace Ploch.EditorConfigTools.Data.SqLite;

public class EditorConfigDbContextFactory : SqLiteDbContextFactory<EditorConfigDbContext, EditorConfigDbContextFactory>
{
    public EditorConfigDbContextFactory() : base(options => new EditorConfigDbContext(options /*,
        new SimpleOptions<OperationalStoreOptions>(new OperationalStoreOptions { ConfigureDbContext = builder => builder.UseSqlite(ApplyMigrationsAssembly) })*/))
    { }
}