using BloggingApp.BloggingDataContext;
using BloggingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloggingApp.Services
{
    public class BlogService : IBlogService
    {
        BloggingDBContext _bloggingDBContext;
        public BlogService(BloggingDBContext bloggingDBContext)
        {
            _bloggingDBContext = bloggingDBContext;
        }

        public List<BlogViewModel> GetBlogsList()
        {
            // To Do: We can implement the Exception filters instead of calling the try catch block every time
            try
            {
                var posts = _bloggingDBContext.Posts;
                var blogViewModel = new List<BlogViewModel>();

                foreach (var post in posts)
                {
                    var author = _bloggingDBContext.Author.Where(x => x.Id == post.AuthorId).FirstOrDefault();
                    var comments = _bloggingDBContext.Comments.Where(x => x.PostId == post.Id).ToList();
                    blogViewModel.Add(new BlogViewModel(author, comments, post));
                }
                if (!blogViewModel.Any())
                {
                    throw new Exception("No record found");
                }

                return blogViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
