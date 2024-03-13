using Domain.Data.Context;
using Domain.Entites.Portal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models.Article;
using ViewModels.Models.Category;

namespace Bussiness.Security
{
    public class ArticleSevices
    {
        public List<ArticleViewModel> GetArticles()
        {
            using (CMSContext context = new CMSContext())
            {
                var users = context.Articles.AsNoTracking()
                                        .Select(x => new ArticleViewModel
                                        {
                                            ArticleId = x.ArticleId,
                                            Title = x.Title,
                                            Content = x.Content,
                                            PublishDate = x.PublishDate
                                        }).ToList();
                return users;
            }
        }
        public EditArticleViewModel GetArticleByIdForEdit(int articleId)
        {
            using (CMSContext context = new CMSContext())
            {
                var article = context.Articles.AsNoTracking()
                    .Where(a => a.ArticleId == articleId)
                    .Select(x => new EditArticleViewModel
                    {
                        ArticleId = x.ArticleId,
                        Title = x.Title,
                        Content = x.Content,
                    }).FirstOrDefault();
                return article;
            }
        }
        public List<CategoryViewModel> GetCategories()
        {
            using (CMSContext context = new CMSContext())
            {
                var categories = context.Categories.AsNoTracking()
                    .Select(x => new CategoryViewModel
                    {
                        CategoryId = x.CategoryId,
                        Title = x.Title
                    }).ToList();
                return categories;
            }
        }
        public bool Similarity(string title, int artileId, out string message)
        {
            using (CMSContext context = new CMSContext())
            {
                bool checkTitle = context.Articles.Where(a => a.Title == title && a.ArticleId != artileId).Any();
                if (checkTitle == true)
                {
                    message = "Duplicated Title";
                    return checkTitle;
                }
                message = "";
                return false;
            }
        }
        public bool Add(AddAritcleViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity(model.Title, model.ArticleId, out checkMessage) == false)
            {
                Article article = new Article()
                {
                    Title = model.Title,
                    Content = model.Content,
                    PublishDate = DateTime.Now,
                    AuthorId = Guid.Parse("5ca717ac-7ccf-454b-90dd-17cbaf732464")
                };
                using (CMSContext context = new CMSContext())
                {
                    context.Articles.Add(article);
                    context.SaveChanges();
                };
                var categories = model.CategoryId;
                foreach (var item in categories)
                {
                    ArticleCategory articleCategory = new ArticleCategory()
                    {
                        ArticleId = article.ArticleId,
                        CategoryId = Convert.ToInt32(item)
                    };
                    using (CMSContext context = new CMSContext())
                    {
                        context.ArticleCategories.Add(articleCategory);
                        context.SaveChanges();
                    }
                }
                message = "";
                return true;
            }
            message = checkMessage;
            return false;
        }
        public bool Edit(ArticleViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity(model.Title, model.ArticleId, out checkMessage) == false)
            {
                using (CMSContext context = new CMSContext())
                {
                    var data = context.Articles.Where(a => a.ArticleId == model.ArticleId).FirstOrDefault();
                    if (data != null)
                    {
                        data.Title = model.Title;
                        data.Content = model.Content;
                        context.SaveChanges();
                        message = "";
                        return true;

                    }
                    //var category = context.ArticleCategories.Where(c=>c.ArticleId==model.ArticleId)
                }
            }
            message = checkMessage;
            return false;
        }
        public bool Delete(ArticleViewModel model)
        {
            using (CMSContext context = new CMSContext())
            {
                var data = context.Articles.Where(a => a.ArticleId == model.ArticleId).FirstOrDefault();
                if (data != null)
                {
                    context.Articles.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        //public bool Add(ArticleViewModel model)
        //{

        //    Article article = new Article()
        //    {
        //        Title = model.Title,
        //        Content = model.Content,
        //        PublishDate = DateTime.Now,
        //        AuthorId = model.AuthorId
        //    };
        //    using (CMSContext context = new CMSContext())
        //    {
        //        context.Articles.Add(article);
        //        context.SaveChanges();
        //    }
        //    return true;
        //}
    }
}
