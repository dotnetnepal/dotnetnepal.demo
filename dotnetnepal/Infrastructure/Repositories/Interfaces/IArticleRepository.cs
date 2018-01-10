using Infrastructure.Core.Domains;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAllArticlesData();
        void SaveArticle(Article article);
        Article GetArticle(Guid Id);
        void DeleteArticle(Guid Id);
    }
}