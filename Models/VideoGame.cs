using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _200223057A1.Models
{
    public class VideoGame
    {
        public VideoGame()
        {
            this.Genres = new HashSet<Genre>();
        }
        public int VideoGameId { get; set; }
        public int PublisherId { get; set; }
        public int DeveloperId { get; set; }
        public int? ReviewId { get; set; } //'?' allows nullable(zero or more)
        public double Price { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Your name cannot be longer than 50 characters.")]
        public String Name { get; set; }
        public String Description { get; set; }
        [Display(Name = "Minimum Requirements")]
        public String MinimumRequirements { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Developer Developer { get; set; }
        public virtual Review Review { get; set; }
        [Required]
        public virtual ICollection<Genre> Genres { get; set; } //Used ICollection to allow HashSet
        
    }
}