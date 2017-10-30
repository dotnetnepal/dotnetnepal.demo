using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
            Title = "My new post";
            //Author = HttpContext.User.Identity.Name;
            Content = "the content";
            PubDate = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
            Categories = new string[0];
            Comments = new List<Comment>();
            IsPublished = true;
        }
        public string Id { get; set; }

     
        public string Title { get; set; }

        public string Author { get; set; }

    
        public string Slug { get; set; }

     
        public string Excerpt { get; set; }
        public string Content { get; set; }

       
        public DateTime PubDate { get; set; }

    
        public DateTime LastModified { get; set; }

        public bool IsPublished { get; set; }

   
        public string[] Categories { get; set; }
        public List<Comment> Comments { get; private set; }
    }
}
