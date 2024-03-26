using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Domain;
using backend.Models.DTO;

namespace backend.Repository
{
    public class BlogPostService
    {
        private readonly IGenericRepository<BlogPost> _blogPostRepository;
        private readonly IGenericRepository<Category> _categoryRespository;
        public BlogPostService(IGenericRepository<BlogPost> blogPostRepository, IGenericRepository<Category> categoryRespository)
        {
            _categoryRespository = categoryRespository;
            _blogPostRepository = blogPostRepository;
        }
    }
}