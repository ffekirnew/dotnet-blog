namespace BlogApp.Application.Common.Exceptions;

public class ServerErrorException : ApplicationException
{
  public ServerErrorException(string message) : base(message)
  { }
}
