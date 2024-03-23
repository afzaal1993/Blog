using backend.Data;
using backend.Models.Domain;
using backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddCategory(CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public Task<IActionResult> UpdateCategory(UpdateCategoryRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
