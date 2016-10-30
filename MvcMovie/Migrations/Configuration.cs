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
                    TaxPercentage = 0.05
                },
                new State
                {
                    Name = "NY",
                    TaxPercentage = 0.05
                },
                new State
                {
                    Name = "TN",
                    TaxPercentage = 0.05
                }
               );

        }

    }
}
