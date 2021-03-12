using BloggingApp.BloggingDataContext;
using BloggingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.Services
{
    public class AuthorService : IAuthorService
    {
        BloggingDBContext _bloggingDBContext;

        public AuthorService(BloggingDBContext bloggingDBContext)
        {
            _bloggingDBContext = bloggingDBContext;
        }

        public void AddAuthor(Author author)
        {
            try
            {
                _bloggingDBContext.Author.Add(author);

                _bloggingDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAuthor(long id)
        {
            try
            {
                var authorToDelete = _bloggingDBContext.Author.Find(id);
                if (authorToDelete == null)
                {
                    throw new Exception("No record Found");
                }

                _bloggingDBContext.Author.Remove(authorToDelete);
                _bloggingDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Deleting the record");
            }
        }

        public void UpdateAuthor(long id, Author author)
        {
            try
            {
                var currentBlog = _bloggingDBContext.Author.Find(id);

                if (currentBlog == null)
                {
                    throw new Exception("Record Not Found");
                }

                currentBlog.Name = author.Name;
                currentBlog.Description = author.Description;

                _bloggingDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Updating the Field");
            }
        }
    }
}
