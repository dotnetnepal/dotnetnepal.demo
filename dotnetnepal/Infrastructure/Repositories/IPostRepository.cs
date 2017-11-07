using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPostsData();
        void SavePost(Post post);
        Post GetPost(Guid Id);
        void DeletePost(Guid Id);
    }
}