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
        [Required]
        public ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}