using BloggingApp.Models;

namespace BloggingApp.Services
{
    public interface IAuthorService
    {
        public void AddAuthor(Author author);
        public void UpdateAuthor(long id, Author author);
        public void DeleteAuthor(long id);
    }
}
