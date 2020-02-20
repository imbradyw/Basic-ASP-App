using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _200223057A1.Models
{
    public class Genre
    {
        public Genre()
        {
            this.VideoGames = new HashSet<VideoGame>();
        }
        public int GenreId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        //Both Genre and VideoGame need a collection of eachother for many2many
        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}