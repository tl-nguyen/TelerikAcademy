using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.WebAPI.Models
{
    public class LikeDataModel
    {
        public static Expression<Func<Like, LikeDataModel>> FromLike
        {
            get
            {
                return c => new LikeDataModel
                {
                    AuthorName = c.Author.UserName,
                    Id = c.Id
                };
            }
        }

        public int Id { get; set; }

        public string AuthorName { get; set; }
    }
}
