using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace PassionProject_Nith.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        public string TrackTitle { get; set; }

        public TimeOnly TrackLength { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
