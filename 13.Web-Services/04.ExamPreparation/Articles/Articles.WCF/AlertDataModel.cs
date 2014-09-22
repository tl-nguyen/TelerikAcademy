using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.WCF
{
    public class AlertDataModel
    {
        public static Expression<Func<Alert, AlertDataModel>> FromAlert
        {
            get
            {
                return a => new AlertDataModel
                {
                    Id = a.Id,
                    Content = a.Content
                };
            }
        }

        public int Id { get; set; }

        public string Content { get; set; }
    }
}
