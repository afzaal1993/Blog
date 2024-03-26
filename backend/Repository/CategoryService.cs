using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Domain;
using backend.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllCategories()
        {
            var categoryDto = await _categoryRepository.Query().Select(category => new GetCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
                IsActive = category.IsActive
            }).ToListAsync();

            return categoryDto;
        }

        public async Task<GetCategoryDto> GetCategoryById(Guid id)
        {
            var categoryDto = await _categoryRepository
                            .Query()
                            .Where(x => x.Id == id)
                            .Select(x => new GetCategoryDto
                            {
                                Id = x.Id,
                                Name = x.Name,
                                UrlHandle = x.UrlHandle,
                                IsActive = x.IsActive
                            })
                            .FirstOrDefaultAsync();

            return categoryDto;
        }
    }
}