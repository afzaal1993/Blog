namespace backend.Models.DTO
{
    public class GetCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public bool IsActive { get; set; }
    }
}
