using backend.Models.Domain;
using backend.Models.DTO;
using backend.Repository;
using backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequestDto request)
        {
            var result = await _categoryRepo.AddCategory(request);

            if (result) return Ok("Category created successfully");

            return BadRequest("Category creation failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequestDto request)
        {
            var result = await _categoryRepo.UpdateCategory(request);

            if (result) return Ok("Category updated successfully");

            return BadRequest("Category update failed");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryRepo.GetAllCategories();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryRepo.GetCategoryById(id);

            return Ok(result);
        }
    }
}
