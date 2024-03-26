using System.ComponentModel.DataAnnotations.Schema;
using BlogApp.Domain.Common;

namespace BlogApp.Domain.Entitites;

public class Like : BaseEntity
{
  [ForeignKey("Post")]
  public int PostId { get; set; }
  [ForeignKey("User")]
  public int UserId { get; set; }
}
