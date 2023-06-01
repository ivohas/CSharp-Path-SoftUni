using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

 public class Writer
{
    public Writer()
    {
        this.Songs= new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.WriterNameMaxLenght)]
    public string Name { get; set; } = null!;

    public string? Pseudonym  { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
}
