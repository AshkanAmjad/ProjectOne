using System.Collections.Generic;

namespace Domain.Entites.Portal.Model
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        public ICollection<ArticleCategories> ArticeCategory { get; set; }
        #endregion
    }
}
