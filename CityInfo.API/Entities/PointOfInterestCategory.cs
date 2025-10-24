using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class PointOfInterestCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        //Navigation Property
        public Category Category { get; set; }

        [ForeignKey("PointOfInterestId")]
        public int PointOfInterestId { get; set; }
        //Navigation Property
        public PointOfInterest PointOfInterest { get; set; }
    }
}
