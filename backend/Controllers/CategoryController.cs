using backend.Models.Domain;
using backend.Models.DTO;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly CategoryService _categoryService;

        public CategoryController(IGenericRepository<Category> categoryRepo, CategoryService categoryService)
        {
            _categoryService = categoryService;
            _categoryRepo = categoryRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
                IsActive = request.IsActive
            };

            var result = await _categoryRepo.AddAsync(category);

            if (result) return Ok("Category created successfully");

            return BadRequest("Category creation failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequestDto request)
        {
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle,
                IsActive = request.IsActive
            };

            var result = await _categoryRepo.UpdateAsync(category);

            if (result) return Ok("Category updated successfully");

            return BadRequest("Category update failed");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategories();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetCategoryById(id);

            return Ok(result);
        }
    }
}
