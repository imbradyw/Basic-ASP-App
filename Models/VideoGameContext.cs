using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _200223057A1.Models
{
    public class VideoGameContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VideoGameContext() : base("name=VideoGameContext")
        {
            this.Database.CommandTimeout = 180;
        }

        public System.Data.Entity.DbSet<_200223057A1.Models.Developer> Developers { get; set; }

        public System.Data.Entity.DbSet<_200223057A1.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<_200223057A1.Models.Publisher> Publishers { get; set; }

        public System.Data.Entity.DbSet<_200223057A1.Models.Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<_200223057A1.Models.VideoGame> VideoGames { get; set; }
    }
}
