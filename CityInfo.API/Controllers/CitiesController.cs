using AutoMapper;
using CityInfo.API.DataStores;
using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using CityInfo.API.GetCategories;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        public CitiesController(IMapper mapper, ICityRepository cityRepository)
        {
           
            _mapper = mapper;
            _cityRepository = cityRepository;
        }
        private const int maxPageSize = 50;

        [HttpGet] // Matches "api/Cities"
        public async Task<ActionResult<IEnumerable<City>>> GetCities(
            [FromQuery] string? searchQuery,
            [FromQuery] string? name,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            ) //just get cities in the example
        {
            if (pageSize > maxPageSize)
            {
                pageSize=maxPageSize;
            }
            var (cities, paginationMetadata) = await _cityRepository.GetCitiesAsync(name,searchQuery,
                 pageNumber,pageSize,
                true);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CityDto>>(cities));
        }

        [HttpGet("{id}")] // Matches "api/Cities/{id}" (e.g., "api/Cities/1")
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityRepository.GetCityAsync(id, true);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CityDto>(city));
            
        }
       
       
    }
}
