using BloggingApp.BloggingDataContext;
using BloggingApp.Models;
using System;

namespace BloggingApp.Services
{
    public class PostService : IPostService
    {
        BloggingDBContext _bloggingDBContext;
        public PostService(BloggingDBContext bloggingDBContext)
        {
            _bloggingDBContext = bloggingDBContext;
        }

        public void AddPosts(Posts post)
        {
            try
            {
                _bloggingDBContext.Posts.Add(post);

                _bloggingDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletePosts(long id)
        {
            try
            {
                var postToDelete = _bloggingDBContext.Posts.Find(id);
                if (postToDelete == null)
                {
                    throw new Exception("No Record found");
                }

                _bloggingDBContext.Posts.Remove(postToDelete);
                _bloggingDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Deleting the record");
            }
        }

        public void UpdatePosts(long id, Posts post)
        {
            try
            {
                var currentBlog = _bloggingDBContext.Posts.Find(id);

                if (currentBlog == null)
                {
                    throw new Exception("Record not found");
                }

                currentBlog.Title = post.Title;
                currentBlog.Content = post.Content;
                currentBlog.Category = post.Category;
                currentBlog.AuthorId = post.AuthorId;

                _bloggingDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}   
