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
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Blog> GetAllBlogsData()
        {
            return appContext.Blogs
               // .Include(c => c).ThenInclude(o => o.OrderDetails).ThenInclude(d => d.Product)
               // .Include(c => c.Orders).ThenInclude(o => o.Cashier)
               // .OrderBy(c => c.Name)
                .ToList();
        }


        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }
    }
}
