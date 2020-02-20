using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _200223057A1.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Your name cannot be longer than 20 characters.")]
        public String Name { get; set; }
        public String Subject { get; set; }
        [Display(Name = "Review")]
        [Required]
        [StringLength(250, 
            ErrorMessage = "Reviews are meant to be brief, please shorten to less than 250 characters.")]
        public String WrittenReview { get; set; }
        [Display(Name = "Rating(1-5)")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int NumberOfStars { get; set; }
    }
}