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
    using Articles.Models;
    using Articles.WebAPI.Models;

    public class CommentsController : BaseController
    {
        public CommentsController(IArticlesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, CommentDataModel comment)
        {
            if (!ModelState.IsValid)
            {
                BadRequest("comment is not valid");
            }

            var userId = this.User.Identity.GetUserId();

            var newComment = new Comment
            {
                ArticleId = id,
                AuthorId = userId,
                Content = comment.Content,
                DateCreated = DateTime.Now
            };

            this.data.Comments.Add(newComment);
            this.data.SaveChanges();

            return Ok();
        }

    }
}
