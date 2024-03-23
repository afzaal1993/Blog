using backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repository
{
    public interface ICategoryRepo
    {
        public Task<bool> AddCategory(CreateCategoryRequestDto request);
        public Task<IActionResult> UpdateCategory(UpdateCategoryRequestDto request);
    }
}
