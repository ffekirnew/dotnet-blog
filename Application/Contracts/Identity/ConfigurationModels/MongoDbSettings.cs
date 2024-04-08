namespace BlogApp.Application.Contracts.Identity.ConfigurationModels;

public class MongoDbSettings
{
  public string Name { get; init; } = "";
  public string ConnectionString { get; init; } = "";
}
