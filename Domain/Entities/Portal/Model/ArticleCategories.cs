namespace Domain.Entites.Portal.Model
{
    public class ArticleCategories
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        #region Relations
        public Articles Article { get; set; }
        public Categories Category { get; set; }
        #endregion

    }
}
