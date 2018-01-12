
using Infrastructure.Repositories;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        int SaveChanges();
    }
}
