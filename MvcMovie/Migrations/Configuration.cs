namespace MvcMovie.Migrations
{
    using MvcMovie.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcMovie.Models.MovieDBContext context)
        {
            context.Movies.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-1-11"),
                    Genre = "Romantic Comedy",
                    Rating = "PG",
                    Price = 7.99M
                },

                 new Movie
                 {
                     Title = "Ghostbusters ",
                     ReleaseDate = DateTime.Parse("1984-3-13"),
                     Genre = "Comedy",
                     Rating = "G",
                     Price = 8.99M
                 },

                 new Movie
                 {
                     Title = "Ghostbusters 2",
                     ReleaseDate = DateTime.Parse("1986-2-23"),
                     Genre = "Comedy",
                     Rating = "G",
                     Price = 9.99M
                 },

               new Movie
               {
                   Title = "Rio Bravo",
                   ReleaseDate = DateTime.Parse("1959-4-15"),
                   Genre = "Western",
                   Rating = "None",
                   Price = 3.99M
               }
           );


            context.Widgets.AddOrUpdate(i => i.Name, 
                new Widget
                {
                    Name = "Widget1",
                    BasePrice = 10.00M,
                    DiscountIndicator = true
                },
                new Widget
                {
                    Name = "Widget2",
                    BasePrice = 100.00M,
                    DiscountIndicator = false
                },
                new Widget
                {
                    Name = "Widget3",
                    BasePrice = 200.00M,
                    DiscountIndicator = true
                }
               );


            context.States.AddOrUpdate(i => i.Name,
                new State
                {
                    Name = "FL",
                    TaxPercentage = 0.0
                },
                new State
                {
                    Name = "TX",
                    TaxPercentage = 0.0
                },
                new State
                {
                    Name = "IN",
                    TaxPercentage = 5.0
                },
                new State
                {
                    Name = "NY",
                    TaxPercentage = 5.0
                },
                new State
                {
                    Name = "TN",
                    TaxPercentage = 5.0
                }
               );

        }

    }
}
