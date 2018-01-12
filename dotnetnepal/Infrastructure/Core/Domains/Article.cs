//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;

//namespace Infrastructure.Core.Domains
//{
//    public class Article
//    {
//        [JsonIgnore]
//        public int ArticleId { get; set; }

//        public string Slug { get; set; }

//        public string Title { get; set; }

//        public string Description { get; set; }

//        public string Body { get; set; }

//        public Person Author { get; set; }

//        public List<Comment> Comments { get; set; }

//        [NotMapped]
//        public bool Favorited => ArticleFavorites?.Any() ?? false;

//        [NotMapped]
//        public int FavoritesCount => ArticleFavorites?.Count ?? 0;

//        [NotMapped]
//        public List<string> TagList => (ArticleTags?.Select(x => x.TagId) ?? Enumerable.Empty<string>()).ToList();

//        [JsonIgnore]
//        public List<ArticleTag> ArticleTags { get; set; }

//        [JsonIgnore]
//        public List<ArticleFavorite> ArticleFavorites { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public DateTime UpdatedAt { get; set; }
//    }

//    public class ArticleFavorite
//    {
//        public int ArticleId { get; set; }
//        public Article Article { get; set; }

//        public int PersonId { get; set; }
//        public Person Person { get; set; }
//    }

//    public class ArticleTag
//    {
//        public int ArticleId { get; set; }
//        public Article Article { get; set; }

//        public string TagId { get; set; }
//        public Tag Tag { get; set; }
//    }

//    public class Comment
//    {
//        [JsonProperty("id")]
//        public int CommentId { get; set; }

//        public string Body { get; set; }

//        public Person Author { get; set; }

//        [JsonIgnore]
//        public Article Article { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public DateTime UpdatedAt { get; set; }
//    }

//    public class FollowedPeople
//    {
//        public int ObserverId { get; set; }
//        public Person Observer { get; set; }

//        public int TargetId { get; set; }
//        public Person Target { get; set; }
//    }
//    public class Person
//    {
//        [JsonIgnore]
//        public int PersonId { get; set; }

//        public string Username { get; set; }

//        public string Email { get; set; }

//        public string Bio { get; set; }

//        public string Image { get; set; }

//        [JsonIgnore]
//        public List<ArticleFavorite> ArticleFavorites { get; set; }

//        [JsonIgnore]
//        public List<FollowedPeople> Following { get; set; }

//        [JsonIgnore]
//        public List<FollowedPeople> Followers { get; set; }

//        [JsonIgnore]
//        public byte[] Hash { get; set; }

//        [JsonIgnore]
//        public byte[] Salt { get; set; }
//    }

//    public class Tag
//    {
//        public string TagId { get; set; }

//        public List<ArticleTag> ArticleTags { get; set; }
//    }

//}
