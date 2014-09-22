namespace Articles.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Articles.Data;

    public class BaseController : ApiController
    {
        protected IArticlesData data;

        public BaseController(IArticlesData data)
        {
            this.data = data;
        }
    }
}