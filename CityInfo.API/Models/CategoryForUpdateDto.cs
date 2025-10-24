using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class CategoryForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name for the category")]
        [MinLength(3, ErrorMessage = "Name has to got at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Name can't be longer then 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should provide a description for the category")]
        [MinLength(3, ErrorMessage = "Description has to got at least 3 characters")]
        public string Description { get; set; }

    }
}
