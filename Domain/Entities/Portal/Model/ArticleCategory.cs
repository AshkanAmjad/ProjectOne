using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entites.Portal.Model
{
    public class ArticleCategory
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        #region Relations
        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        #endregion

    }
}
