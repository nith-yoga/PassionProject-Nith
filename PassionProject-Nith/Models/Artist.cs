using System.ComponentModel.DataAnnotations;

namespace PassionProject_Nith.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

     
        public string ArtistName { get; set; }

        public string? ArtistBio {  get; set; }

        //Collect Album Ids Associated with Artist
        public virtual ICollection<Album>? Albums { get; set; } = new List<Album>();

    }

}
