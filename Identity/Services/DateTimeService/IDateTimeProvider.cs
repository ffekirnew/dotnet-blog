namespace BlogApp.Identity.Services.DateTimeService;

public interface IDateTimeProvider
{
  public DateTime UtcNow { get; }
}
