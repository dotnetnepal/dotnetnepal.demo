using Infrastructure.Core.Domains;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{

    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Article> GetAllArticlesData()
        {
            return appContext.Articles
               .Include(c => c.Comments)
                .OrderBy(c => c.CreatedAt)
                .ToList();
        }
        public IEnumerable<Comment> GetAllCommentsData()
        {
            return appContext.Comments
                          .OrderBy(c => c.CreatedAt)
                .ToList();
        }

        public Article GetArticle(Guid Id)
        {
            return appContext.Articles.Find(Id);
        }



        public void SaveArticle(Article article)
        {
            appContext.Add(article);
            appContext.SaveChanges();
        }
        public void DeleteArticle(Guid Id)
        {
            appContext.Remove(GetArticle(Id));
            appContext.SaveChanges();

        }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }
    }
}
