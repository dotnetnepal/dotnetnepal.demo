using Infrastructure.Core.Domains;

namespace dotnetnepal.Features.Articles
{
    public class ArticleEnvelope
    {
        public ArticleEnvelope(Article article)
        {
            Article = article;
        }

        public Article Article { get; }
    }
}
