using Book_Management.Models.ViewModels;
using Book_Management.Services.Communication;

namespace Book_Management.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}
