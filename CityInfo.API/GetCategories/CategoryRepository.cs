using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.GetCategories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CityInfoContext _context;
        public CategoryRepository(CityInfoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
          
           return await _context.Categories.ToListAsync();
        }
        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }
        public void AddCategory(Category category)
        {
          
            _context.Categories.Add(category);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
