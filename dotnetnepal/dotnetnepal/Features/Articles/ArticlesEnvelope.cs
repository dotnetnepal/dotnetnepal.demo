using Infrastructure.Core.Domains;
using System.Collections.Generic;
using System.Linq;

namespace dotnetnepal.Features.Articles
{
    public class ArticlesEnvelope
    {
        public List<Article> Articles { get; set; }

        public int ArticlesCount => Articles?.Count ?? 0;
    }
}
