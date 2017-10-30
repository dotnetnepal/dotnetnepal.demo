using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        IBlogRepository _blogs;
        readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBlogRepository Blogs
        {
            get
            {
                if (_blogs == null)
                    _blogs = new BlogRepository(_context);

                return _blogs;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
