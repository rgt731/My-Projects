namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //important - didn't know what a movie was, had to add this
    using PikYak.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PikYak.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PikYak.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Yaks.AddOrUpdate(
                  p => p.Id, 
                  new Yak { Text = "Just checking out the time stamp!!!", Latitude = 69, Longitude = 102, Positivity = 99, Timestamp = new DateTime(1985, 2, 28) },
                  new Yak { Text = "This is my first yak, its super positive", Latitude = 69, Longitude = 102, Positivity = 99, Timestamp = DateTime.Now  },
                  new Yak { Text = "This is my second yak, its somewhat positive", Latitude = 87, Longitude = 304, Positivity = 55, Timestamp = DateTime.Now },
                  new Yak { Text = "Just checking out the time stamp again!!!", Latitude = 69, Longitude = 102, Positivity = 99, Timestamp = new DateTime(2014, 4, 20) },
                  new Yak { Text = "This is my third yak, its a little positive", Latitude = 17, Longitude = 44, Positivity = 17, Timestamp = DateTime.Now },
                  new Yak { Text = "Just checking out the time stamp again!!!", Latitude = 69, Longitude = 102, Positivity = 99, Timestamp = new DateTime(2015, 4, 20) }

                );
               
                /*seed method for likes?...maybe?*/
                context.Likes.AddOrUpdate(
                 l => l.Id,
                 new Like { UserId = "Bruce Wayne",YakId = 10, Timestamp = DateTime.Now,  },
                 new Like { UserId = "Clark Kent", YakId = 7, Timestamp = DateTime.Now, },
                 new Like { UserId = "Louis Lane", YakId = 5, Timestamp = DateTime.Now, }


               );

        }
    }
}
