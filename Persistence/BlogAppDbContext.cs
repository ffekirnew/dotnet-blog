namespace BlogApp.Persistence;

using Microsoft.EntityFrameworkCore;
using BlogApp.Domain.Entitites;

public class BlogAppDbContext : DbContext
{
  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Post> Posts { get; set; } = null!;
  public DbSet<Comment> Comments { get; set; } = null!;
  public DbSet<Like> Likes { get; set; } = null!;
  public DbSet<Share> Shares { get; set; } = null!;
  public DbSet<Tag> Tags { get; set; } = null!;

  public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options)
      : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}
