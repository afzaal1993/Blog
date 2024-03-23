using backend.Models.DTO;
using backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryRequestDto request)
        {
            var result = await _categoryRepo.AddCategory(request);

            if (result) return Created();

            else return BadRequest();
        }
    }
}
