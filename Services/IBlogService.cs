using BloggingApp.ViewModels;
using System.Collections.Generic;

namespace BloggingApp.Services
{
    public interface IBlogService
    {
        public List<BlogViewModel> GetBlogsList();
    }
}
