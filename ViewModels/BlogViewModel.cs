using BloggingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.ViewModels
{
    public class BlogViewModel
    {
        public BlogViewModel(Author author, List<Comments> comments, Posts post)
        {
            this.Author = author;
            this.Comments = comments;
            this.Title = post.Title;
            this.Content = post.Content;
            this.Category = post.Category;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Category { get; set; }

        public Author Author { get; set; }

        public List<Comments> Comments { get; set; }
    }
}
