using Microsoft.AspNetCore.Mvc.Rendering;

namespace PassionProject_Nith.Models
{
    public class AlbumCreateViewModel
    {
        public string AlbumTitle { get; set; }

        public string Genre { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int ArtistId { get; set; }

        public IEnumerable<SelectListItem> Artists { get; set; }
    }
}
