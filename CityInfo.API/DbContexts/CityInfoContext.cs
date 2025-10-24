using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext(DbContextOptions<CityInfoContext> options) : DbContext(options)

    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PointOfInterestCategory> PointOfInterestCategories { get; set; }

        //many to many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PointOfInterest>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.PointsOfInterest)
                .UsingEntity<PointOfInterestCategory>();

            //seed the database
            modelBuilder.Entity<City>().HasData(
    new City("New York City")
    {
        Id = 1,
        Description = "The one with that big park."
    },
    new City("Antwerp")
    {
        Id = 2,
        Description = "The one with the cathedral that was never really finished."
    },
    new City("Paris")
    {
        Id = 3,
        Description = "The one with that big tower."
    }
);

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Central Park")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "The most visited urban park in the United States."

                },
                new PointOfInterest("Empire State Building")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "A 102-story skyscraper located in Midtown Manhattan."
                },
                new PointOfInterest("Cathedral")
                {
                    Id = 3,
                    CityId = 2,
                    Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                },
                new PointOfInterest("Antwerp Central Station")
                {
                    Id = 4,
                    CityId = 2,
                    Description = "The the finest example of railway architecture in Belgium."
                },
                new PointOfInterest("Eiffel Tower")
                {
                    Id = 5,
                    CityId = 3,
                    Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                },
                new PointOfInterest("The Louvre")
                {
                    Id = 6,
                    CityId = 3,
                    Description = "The world's largest museum."
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category("Historical Site", "This category includes landmarks, monuments, and sites of historical significance such as museums, forts, ancient ruins, and heritage buildings.")
                {
                    Id = 1
                },
                new Category("Natural Attractions", "Natural attractions encompass parks, gardens, beaches, mountains, lakes, waterfalls, and other scenic spots where visitors can enjoy nature and outdoor activities.")
                {
                    Id = 2
                },
                new Category("Cultural Centers", "This category includes theaters, art galleries, performance venues, and cultural institutions where visitors can experience art, music, dance, theater, and other cultural events.")
                {
                    Id = 3
                },
                new Category("Restaurants and Cafés", "Dining establishments ranging from fine dining restaurants to casual eateries, cafes, food markets, and street food vendors offering a variety of cuisines and culinary experiences.")
                {
                    Id = 4
                },
                new Category("Outdoor Activities", "Activities such as hiking trails, biking paths, water sports facilities, adventure parks, and recreational areas where visitors can engage in outdoor pursuits.")
                {
                    Id = 5
                }
            );

            modelBuilder.Entity<PointOfInterestCategory>().HasData(
                new PointOfInterestCategory()
                {
                    Id = 1,
                    PointOfInterestId = 1,
                    CategoryId = 2
                },
                new PointOfInterestCategory()
                {
                    Id = 2,
                    PointOfInterestId = 1,
                    CategoryId = 5
                },
                new PointOfInterestCategory()
                {
                    Id = 3,
                    PointOfInterestId = 2,
                    CategoryId = 3
                },
                new PointOfInterestCategory()
                {
                    Id = 4,
                    PointOfInterestId = 3,
                    CategoryId = 1
                },
                new PointOfInterestCategory()
                {
                    Id = 5,
                    PointOfInterestId = 3,
                    CategoryId = 3
                }
            );
        }


    }
}
