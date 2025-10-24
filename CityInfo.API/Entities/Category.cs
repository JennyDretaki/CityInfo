using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        //many to many
        public  ICollection<PointOfInterest> PointsOfInterest { get; set; }  =new List<PointOfInterest>();
        public ICollection<PointOfInterestCategory> PointOfInterestCategories { get; set; } = new List<PointOfInterestCategory>() ;


        //constructor
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
