using Domain.Entites.Portal.Model;
using Domain.Entites.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entities.Portal.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public Guid UserId { get; set; }
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        public Article Article { get; set; }
        public User User { get; set; }
        #endregion
    }
}
