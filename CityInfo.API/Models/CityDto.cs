namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        //public string Name { get; set; } = string.Empty;
        public string Name { get; set; }
        public string? Description { get; set; }

        // List of POIs
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();

        //Calculated property
        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

    }

}
