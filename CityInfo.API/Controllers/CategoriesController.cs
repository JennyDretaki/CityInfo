using AutoMapper;
using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.GetCategories;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Http;
//using CityInfo.API.DataStores;

namespace CityInfo.API.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriesController : ControllerBase //always inherits from ControllerBase
        {
          
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;

            private readonly ILogger<CategoriesController> _logger;
        public CategoriesController(IMapper mapper,
        ICategoryRepository categoryRepository,
        ILogger<CategoriesController> logger)//I dont forget to connect it with my database and mapper
        {
            _mapper = mapper; //It's reffering to MappingProfiles folder that we define in program.cs
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories() //just get cities in the example
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
                     
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            throw new Exception("Get Category Exception"); //to test the exception handling middleware
            
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                _logger.LogInformation($"Category with id {id} was not found when accessing the GetCategory");
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            
           _categoryRepository.AddCategory(categoryEntity);
            await _categoryRepository.SaveChangesAsync();



            var createdCategoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtAction(nameof(GetCategory),
                new
                {
                    id = createdCategoryToReturn.Id
                },
                createdCategoryToReturn);
        }
        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategory(int categoryId, CategoryForUpdateDto category)
        {
            var categoryEntity = await _categoryRepository.GetCategoryAsync(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            // Automapper will override values from source to destination
            // Values from incoming DTO are used to override the entity values
            _mapper.Map(category, categoryEntity);

            //CategoryEntity is tracked by DbContext : it knows there are changes!
            //Save those changes to database!
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }
 

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            var categoryEntity = await _categoryRepository.GetCategoryAsync(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            _categoryRepository.DeleteCategory(categoryEntity);
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{categoryId}")]
        public async Task<ActionResult> PartiallyUpdateCategory(int categoryId,
                JsonPatchDocument<CategoryForUpdateDto> patchDocument)//we wrap the Dto in a Patch document
        {
            var  categoryEntity = await _categoryRepository.GetCategoryAsync(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            // Map entity to update DTO
            var categoryToPatch = _mapper.Map<CategoryForUpdateDto>(categoryEntity);

            // Validation
            patchDocument.ApplyTo(categoryToPatch, ModelState);

            // Patch is done, check validity and correspond accordingly
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!TryValidateModel(categoryToPatch))
            {
                return BadRequest(ModelState);
            }

            // DTO is valid --> map back to entity and save changes
            _mapper.Map(categoryToPatch, categoryEntity);

            // Persist changes to database
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }


    }

}
