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
        IPostRepository _posts;
        readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPostRepository Posts
        {
            get
            {
                if (_posts == null)
                    _posts = new PostRepository(_context);

                return _posts;
            }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
