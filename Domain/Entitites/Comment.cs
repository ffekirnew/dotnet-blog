using System.ComponentModel.DataAnnotations.Schema;
using BlogApp.Domain.Common;

namespace BlogApp.Domain.Entitites;

public class Comment : BaseEntity
{
  [ForeignKey("Post")]
  public int PostId { get; set; }
  [ForeignKey("User")]
  public int UserId { get; set; }
  public string? Text { get; set; }
}
