using Domain.Entites.Security.Model;
using System;
using System.Collections.Generic;

namespace Domain.Entites.Portal.Model
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AuthorId { get; set; }

        #region Relations
        public virtual ICollection<ArticleCategory> ArticeCategory { get; set; }

        public User Author { get; set; }
        #endregion
    }
}
