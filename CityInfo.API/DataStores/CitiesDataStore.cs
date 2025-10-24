using CityInfo.API.Models;

namespace CityInfo.API.DataStores
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //Singleton
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        private CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park." ,
                    PointsOfInterest = new List<PointOfInterestDto>() {
                            new PointOfInterestDto() {Id=1, Name="Central Park", Description="The most visited urban park in the United States." },
                            new PointOfInterestDto() {Id=2, Name="Empire State Building", Description="A 102-story skyscraper located in Midtown Manhattan." },
                            new PointOfInterestDto() {Id=3, Name="Statue of Liberty", Description="A colossal neoclassical sculpture on Liberty Island in New York Harbor." }
                   }
                },
                new CityDto() {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished." ,
                    PointsOfInterest = new List<PointOfInterestDto>() {
                            new PointOfInterestDto() {Id=1, Name="Cathedral of Our Lady", Description="A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans." },
                            new PointOfInterestDto() {Id=2, Name="Antwerp Central Station", Description="The world's oldest railway arch in the world." }
                            }
            },
                new CityDto() {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                 {new PointOfInterestDto() {Id=1, Name="Eiffel Tower", Description="A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." }
                 }
                } 
            };
        }
    }
}


   

