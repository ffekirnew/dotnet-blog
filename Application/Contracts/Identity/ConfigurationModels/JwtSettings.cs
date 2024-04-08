namespace BlogApp.Application.Contracts.Identity.ConfigurationModels;

public class JwtSettings
{
  public const string SectionName = "JwtSettings";
  public string Issuer { get; set; } = "";
  public string Audience { get; set; } = "";
  public string Key { get; set; } = "";
  public int DurationInMinutes { get; set; }
}
