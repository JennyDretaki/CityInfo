using CityInfo.API.Entities;

namespace CityInfo.API.GetCategories
{
    public interface ICategoryRepository
    {
       
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category?> GetCategoryAsync(int categoryId);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        Task<bool> SaveChangesAsync();

    }
}
