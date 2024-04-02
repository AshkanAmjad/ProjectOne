using System;

namespace ViewModels.Models.Article
{
    public class AddAritcleViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AuthorId { get; set; }
        public Array CategoryId { get; set; }
    }
}
