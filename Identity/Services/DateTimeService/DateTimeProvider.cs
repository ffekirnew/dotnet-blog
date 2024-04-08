namespace BlogApp.Identity.Services.DateTimeService;

public class DateTimeProvider : IDateTimeProvider
{
  public DateTime UtcNow => DateTime.UtcNow;
}
