using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Razor;

namespace MusicHub.Models
{
    public class Concert
    {
        public int Id { get; set; }
       
        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}