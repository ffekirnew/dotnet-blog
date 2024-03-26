namespace BlogApp.Domain.Entitites;

using BlogApp.Domain.Common;

public class User : BaseEntity
{
  public int ApplicationUserId { get; set; }

  public string? Firstname { get; set; }
  public string? Lastname { get; set; }
  public string? Username { get; set; }
  public string? Email { get; set; }
  public string? Bio { get; set; }
  public string? ProfilePicture { get; set; }

  public string? Role { get; set; }

  public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
  public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
  public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
  public virtual ICollection<Share> Shares { get; set; } = new HashSet<Share>();
}

