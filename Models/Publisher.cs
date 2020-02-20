using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _200223057A1.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required]
        [StringLength(75, ErrorMessage = "Your name cannot be longer than 75 characters.")]
        public String Name { get; set; }
        public String Website { get; set; }
    }
}