﻿namespace BloggingApp.Models
{
    public class Comments
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long PostId { get; set; }
    }
}
