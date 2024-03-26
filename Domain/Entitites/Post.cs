using System.ComponentModel.DataAnnotations.Schema;
using BlogApp.Domain.Common;

namespace BlogApp.Domain.Entitites;

public class Post : BaseEntity
{
  [ForeignKey("User")]
  public int UserId { get; set; }
  public string? Title { get; set; }
  public string? Content { get; set; }

  public double AverageRating { get; set; }
  public int NumberOfLikes { get; set; }
  public int NumberOfShares { get; set; }

  public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
  public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
  public virtual ICollection<Share> Shares { get; set; } = new HashSet<Share>();
  public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}
