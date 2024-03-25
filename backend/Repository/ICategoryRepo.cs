using backend.Models.Domain;
using backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repository
{
    public interface ICategoryRepo
    {
        public Task<bool> AddCategory(CreateCategoryRequestDto request);
        public Task<bool> UpdateCategory(UpdateCategoryRequestDto request);
        public Task<List<GetCategoryDto>> GetAllCategories();
    }
}
