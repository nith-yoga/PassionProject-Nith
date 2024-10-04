using System.ComponentModel.DataAnnotations;

namespace PassionProject_Nith.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        
        public string AlbumTitle { get; set; }

        public string Genre { get; set; }

        public DateOnly ReleaseDate { get; set; }

        //Foreign Key to call Artist
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
