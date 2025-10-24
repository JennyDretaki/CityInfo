using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using CityInfo.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.GetCategories
{
    
    public class CityRepository : ICityRepository
    {
        private readonly CityInfoContext _context;
        public CityRepository(CityInfoContext context)
        {
            _context = context;
        }
        public async Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(
            string? searchQuery,
            string? name, 
            int pageNumber,
            int pageSize,
            bool includePOIs = false)
        {
            //Avoid null reference exceptions
            name = name?.Trim();
            searchQuery = searchQuery?.Trim();

            //start with the full connection

            var collection = _context.Cities.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                collection = collection.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                collection = collection.Where(c => c.Name.Contains(searchQuery) 
                || (c.Description != null && c.Description.Contains(searchQuery)));
            }


            if (includePOIs)
            {
                collection = collection.Include(c => c.PointsOfInterest);
            }
            //DB call to get total amount of items
            var totalItemCount = await collection.CountAsync();

            //construct pagination metadata
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection
                .OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }
        public async Task<City?> GetCityAsync(int cityId, bool includePOIs = false)
        {
            var collection = _context.Cities.AsQueryable();
            if (includePOIs)
            {
                collection = collection.Include(c => c.PointsOfInterest);
            }
            return await collection.FirstOrDefaultAsync(c => c.Id == cityId);
        }
    }
}
