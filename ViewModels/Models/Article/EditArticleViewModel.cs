using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models.Article
{
    public class EditArticleViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Array CategoryId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
