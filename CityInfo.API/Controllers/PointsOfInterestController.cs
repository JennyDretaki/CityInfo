using AutoMapper;
using CityInfo.API.DataStores;
using CityInfo.API.DbContexts;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsOfInterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly CityInfoContext _context;
        private readonly IMapper _mapper;
        public PointsOfInterestController(CityInfoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = _context.Cities.Include(c => c.PointsOfInterest).ThenInclude(p => p.Categories).FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(city.PointsOfInterest));
        }

        [HttpGet("{pointOfInterestId}")]
        public ActionResult<PointOfInterestDto> GetPointsOfInterest(int cityId, int pointOfInterestId)
        {
            var city = _context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var POI = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);

            if (POI == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(POI));
        }
    }


}