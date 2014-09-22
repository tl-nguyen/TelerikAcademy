namespace Articles.WebAPI.Controllers
{
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

    public class ArticlesController : BaseController
    {
        private const int defaultPageSize = 10;

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
            return Get(null, 0);
        }

        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            return Get(category, 0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            return Get(null, page);
        }

        [HttpGet]
        public IHttpActionResult Get(string category, int page)
        {
            var articles = GetAllSortedByDate()
                    .Skip(page * defaultPageSize)
                    .Where(a => category != null ? a.Category == category : true)
                    .Take(defaultPageSize);

            return Ok(articles);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var article = this.data.Articles.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            var articleDetails = new ArticleDetailsDataModel(article);

            return Ok(articleDetails);
        }

        private IQueryable<ArticleDataModel> GetAllSortedByDate()
        {
            var articles = this.data.Articles.All()
                    .OrderByDescending(a => a.DateCreated)
                    .Select(ArticleDataModel.FromArticle);

            return articles;
        }
    }
}
