using Infrastructure.Models;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>,IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Post> GetAllPostsData()
        {
            return appContext.Posts
               .Include(c => c.Comments)
                .OrderBy(c => c.PubDate)
                .ToList();
        }
        public Post GetPost(Guid Id)
        {
            return appContext.Posts.Find(Id);
        }
     
        

        public void SavePost(Post post)
        {
            appContext.Add(post);
        }
        public void DeletePost(Guid Id)
        {
            appContext.Remove(GetPost(Id));
        }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }
    }
}
