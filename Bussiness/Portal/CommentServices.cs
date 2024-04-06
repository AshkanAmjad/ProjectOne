using ClassLibrary1.Entities.Portal.Model;
using Domain.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models.Comment;

namespace Bussiness.Portal
{
    public class CommentServices
    {
        public List<CommentViewModel> Get(int articleId)
        {
            using (CMSContext context = new CMSContext())
            {
                var comments = context.Comments.AsNoTracking()
                                               .Where(c=>c.ArticleId==articleId && c.IsActive == true)
                                               .Select(x => new CommentViewModel
                                             {
                                                 CommentId = x.CommentId,
                                                 UserId = x.UserId,
                                                 Title=x.Title,
                                                 Content = x.Content,
                                                 CreateDate=x.CreateDate,
                                             }).ToList();
                return comments;
            }
        }
        public bool Add(AddCommentViewModel model, out string message)
        {
            if (model != null) {
                Comment comment = new Comment()
                {
                    ArticleId = model.ArticleId,
                    Title=model.Title,
                    Content = model.Content,
                    CreateDate = DateTime.Now,
                    IsActive = false
                };
                using (CMSContext context = new CMSContext())
                {
                    context.Comments.Add(comment);
                    context.SaveChanges();
                }
                message = "Successful Recorded"; 
                return true;
            }
            message = "Error";
            return false;
        }
        public bool Edit(EditCommentViewModel model, out string message)
        {
            if (model != null)
            {
                using(CMSContext context=new CMSContext())
                {
                    var data = context.Comments.Where(a => a.CommentId == model.CommentId).FirstOrDefault();
                    if (data != null)
                    {
                        data.Title = model.Title;
                        data.Content = model.Content;
                        data.CreateDate = DateTime.Now;
                        data.IsActive = model.IsActive;
                    }
                    context.SaveChanges();
                    message = "Successfully Edited";
                    return true;
                }
            }
            message = "Error";
            return false;            
        }
        public bool Delete(DeleteCommentViewModel model, out string message)
        {
            if(model != null)
            {
                  using(CMSContext context=new CMSContext())
                  {
                       var data = context.Comments.Where(c => c.CommentId == model.CommentId).FirstOrDefault();
                       if(data != null)
                       {
                        context.Comments.Remove(data);
                        context.SaveChanges();
                        message = "Successfully Deleted";
                        return true;
                       }
                  }
            }
            message = "Error";
            return false;
        } 
    }
}