using System;
using System.Collections.Generic;
using System.Linq;
using EpamBlog.Models;
using EpamBlog.Models.Repository;


namespace EpamBlog.SiteLogic
{
    public class AdminManager
    {
        private Repository repository = new Repository();

        private const short MAX_TAG_AMOUNT = 20;


        public string[] GetMostPopularTags()
        {
            List<Tag> tags = repository.GetTagsWithArticles().ToList();

            Dictionary<string, int> tagCount = new Dictionary<string, int>();

            foreach (Tag tag in tags)
            {
                tagCount[tag.Name] = tag.Articles.Count();
            }


            return tagCount.OrderByDescending(x => x.Value)
                           .Take(MAX_TAG_AMOUNT)
                           .Select(x => x.Key)
                           .ToArray();
        }

        public Article createArticle( AddArticleViewModel _article )
        {
            string[] tagArray = _article.Tags.Split('#').ToArray();
            List<Tag> Tags = new List<Tag>();

            Article newArticle = new Article
            {
                Title = _article.Title,
                Text = _article.Text,
                Published = DateTime.UtcNow
            };

            foreach (string tag in tagArray.Where(x => x != String.Empty))
            {
                Tags.Add(new Tag { Name = tag, Articles = new List<Article> { newArticle } });
            }

            newArticle.Tags = Tags;

            return newArticle;
        }
    }
}