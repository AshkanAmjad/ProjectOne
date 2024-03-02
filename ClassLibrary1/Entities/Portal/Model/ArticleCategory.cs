namespace Domain.Entites.Portal.Model
{
    public class ArticleCategory
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        #region Relations
        public Article Article { get; set; }
        public Category Category { get; set; }
        #endregion

    }
}
