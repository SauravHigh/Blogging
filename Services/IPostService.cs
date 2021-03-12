using BloggingApp.Models;

namespace BloggingApp.Services
{
    public interface IPostService
    {
        public void AddPosts(Posts post);
        public void UpdatePosts(long id, Posts post);
        public void DeletePosts(long id);
    }
}
