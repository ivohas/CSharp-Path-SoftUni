namespace ForumApp.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Post
{
    public Post()
    {
        this.Id = Guid.NewGuid();
    }
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1500)]
    public string Content { get; set; } = null!;
}
