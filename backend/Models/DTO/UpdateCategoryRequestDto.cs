﻿namespace backend.Models.DTO
{
    public class UpdateCategoryRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
