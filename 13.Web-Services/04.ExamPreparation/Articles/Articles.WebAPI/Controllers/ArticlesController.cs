using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Microsoft.AspNet.Identity;

using Articles.Data;
using Articles.WebAPI.Models;
using Articles.Models;

namespace Articles.WebAPI.Controllers
{
    public class ArticlesController : BaseController
    {
        public ArticlesController(IArticlesData data)
            : base (data)
        {
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(ArticleDataModel article)
        {
            var tags = GetTags(article);
            var category = GetCategory(article.Category);
            var userId = this.User.Identity.GetUserId();

            var newArticle = new Article
            {
                Title = article.Title,
                Content = article.Content,
                CategoryId = category.Id,
                Tags = tags,
                AuthorId = userId,
                DateCreated = DateTime.Now
            };

            this.data.Articles.Add(newArticle);
            this.data.SaveChanges();

            article.Id = newArticle.Id;
            article.DateCreated = newArticle.DateCreated;
            article.Tags = newArticle.Tags.AsQueryable().Select(TagDataModel.FromTag).ToArray();

            return Ok(article);
        }

        private Category GetCategory(string categoryName)
        {
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName
                };

                this.data.Categories.Add(category);
            }

            return category;
        }

        private ICollection<Tag> GetTags(ArticleDataModel article)
        {
            var titleTags = article.Title.Split(' ');
            var allTags = new HashSet<string>(titleTags);

            foreach (var articleTag in article.Tags)
            {
                allTags.Add(articleTag.Name);
            }

            var articleTags = new HashSet<Tag>();
            foreach (var tagName in allTags)
            {
                var tag = this.data.Tags.All()
                .FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    this.data.Tags.Add(tag);
                }

                articleTags.Add(tag);
            }

            return articleTags;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var articles = this.data.Articles.All()
                    .Take(10)
                    .Select(ArticleDataModel.FromArticle);

            return Ok(articles);
        }
    }
}
