using BloggingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingApp.BloggingDataContext
{
    public class BloggingDBContext : DbContext
    {
        public BloggingDBContext(DbContextOptions<BloggingDBContext> options): base(options)
        {

        }

        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
