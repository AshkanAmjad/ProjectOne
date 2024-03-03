using System.Collections.Generic;

namespace Domain.Entites.Portal.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        public virtual ICollection<ArticleCategory> ArticeCategory { get; set; }
        #endregion
    }
}
