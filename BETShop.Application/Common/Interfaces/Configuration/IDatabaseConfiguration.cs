namespace BETShop.Application.Common.Interfaces.Configuration
{
    public interface IDatabaseConfiguration
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
