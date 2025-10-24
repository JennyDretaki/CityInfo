using CityInfo.API.Entities;
using CityInfo.API.Services;

namespace CityInfo.API.GetCategories
{
    public interface ICityRepository
    {
        Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string?name, string?searchQuery,int pageSize, int pageNumber , bool includePOIs = false);
        Task<City?> GetCityAsync(int cityId, bool includePOIs = false);

    }
}
