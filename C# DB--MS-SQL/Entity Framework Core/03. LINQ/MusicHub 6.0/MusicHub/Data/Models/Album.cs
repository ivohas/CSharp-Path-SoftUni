using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models;

public  class Album
{
    public Album()
    {
        this.Songs = new HashSet<Song>();
    }
    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.AlbumNameMaxLenght)]
    public string Name { get; set; }=null!;

    public DateTime ReleaseDate { get; set; }

    [NotMapped]
    public decimal Price 
        => this.Songs.Sum(s => s.Price);
    // to do 

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }

    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
}
