using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _200223057A1.Models
{
    public class VideoGameStoreInitializer : DropCreateDatabaseAlways<VideoGameContext>
    {
        protected override void Seed(VideoGameContext context)
        {
            context.Database.CommandTimeout = 0;

            Genre genre1 = new Genre { Name = "RPG", Description = "Roleplaying game." };
            Genre genre2 = new Genre
            {
                Name = "MMORPG",
                Description = "Massive multiplayer online roleplaying game."
            };
            Developer developer1 = new Developer
            {
                Name = "Blizzard Entertainment",
                Website = "www.blizzard.ca"
            };
            Developer developer2 = new Developer
            {
                Name = "Epic Games",
                Website = "www.epicgames.com"
            };
            Publisher publisher1 = new Publisher
            {
                Name = "Nintendo",
                Website = "www.nintendo.com"
            };
            Publisher publisher2 = new Publisher
            {
                Name = "Electronic Arts",
                Website = "www.ea.com"
            };
            context.Genres.Add(genre1);
            context.Genres.Add(genre2);
            context.Developers.Add(developer1);
            context.Developers.Add(developer2);
            context.Publishers.Add(publisher1);
            context.Publishers.Add(publisher2);

            base.Seed(context);
        }
    }
}