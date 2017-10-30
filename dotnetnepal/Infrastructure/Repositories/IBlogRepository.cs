using Infrastructure.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAllBlogsData();
    }
}