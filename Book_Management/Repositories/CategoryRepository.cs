using Book_Management.Models.Database;
using Book_Management.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Book_Management.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            List<CategoryDB> categories = await _context.Categories.ToListAsync();
            List<Category> categoriesVM = new List<Category>();

            foreach (var category in categories)
            {
                categoriesVM.Add(new Category
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return categoriesVM;
        }

        public async Task AddAsync(Category category)
        {
            CategoryDB categoryDB = new CategoryDB
            {
                Name = category.Name
            };
            await _context.Categories.AddAsync(categoryDB);
            _context.SaveChanges();
        }
    }
}