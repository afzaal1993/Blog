﻿using backend.Data;
using backend.Models.Domain;
using backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<GetCategoryDto>> GetAllCategories()
        {
            var categories = await _appDbContext.Categories.Select(category =>  new GetCategoryDto {Id = category.Id, Name = category.Name, UrlHandle = category.UrlHandle }).ToListAsync();

            return categories;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryRequestDto request)
        {
            var category = await _appDbContext.Categories.FindAsync(request.Id);

            if(category == null) return false;

            category.Name = request.Name;
            category.UrlHandle = request.UrlHandle;

            _appDbContext.Categories.Update(category);

            int result = await _appDbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
