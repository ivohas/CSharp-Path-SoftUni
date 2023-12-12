namespace ForumApp.Data.Models;

using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants.Post;
public class Post
{

    public int Id { get; init; }

    [Required]
    [MaxLength(TitleMaxLenght)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLenght)]
    public string Content { get; set; } = null!;
}
