namespace BlogApp.Domain.Entitites;

using System.ComponentModel.DataAnnotations.Schema;
using BlogApp.Domain.Common;

public class Share : BaseEntity
{
  [ForeignKey("Post")]
  public int PostId { get; set; }
  [ForeignKey("User")]
  public int UserId { get; set; }
}
