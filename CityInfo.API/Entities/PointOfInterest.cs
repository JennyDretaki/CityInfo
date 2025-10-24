using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CityInfo.API.Entities
{
    public class PointOfInterest
    {
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        //many-to-one relationship
        //The foreign key property is not nullable. This makes the relationship "required" because every dependent
        // (POI) must be related to some principal (City), since its foreign key property must be set to some value.
        [ForeignKey("CityId")]
        public int CityId { get; set; }

        public City City { get; set; }


        // many-to-many relationship
        public ICollection<Category> Categories { get; set; }
            = new List<Category>();
        public ICollection<PointOfInterestCategory> PointOfInterestCategories { get; set; }
            = new List<PointOfInterestCategory>();

        //constructor (description is optional)
        public PointOfInterest(string name)
        {
            Name = name;
        }



    }

}
