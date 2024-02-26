using Domain.Entites.Security.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entites.Portal.Model
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public Guid AuthorId { get; set; }

        #region Relations
        public ICollection<ArticleCategory> ArticeCategory { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }
        #endregion
    }
}
