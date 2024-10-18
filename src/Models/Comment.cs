using Ploch.Data.Model;

namespace Ploch.EditorConfigTools.Models;

public class Comment : IHasId<int>, IHasValue<string>
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;
    
    public virtual ConfigSection? ConfigSection { get; set; }
    
    public virtual ConfigEntry? ConfigEntry { get; set; }
}