﻿namespace backend.Models.DTO
{
    public class CreateCategoryRequestDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public bool IsActive { get; set; }
    }
}
