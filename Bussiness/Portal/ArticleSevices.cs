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
                var articles = context.Articles.AsNoTracking()
                                        .Select(x => new ArticleViewModel
                                        {
                                            ArticleId = x.ArticleId,
                                            Title = x.Title,
                                            Content = x.Content,
                                            Description=x.Description,
                                            PublishDate = x.PublishDate
                                        }).ToList();
                return articles;
            }
        }
        public IEnumerable<ArticleViewModel> GetArticle(int articleId)
        {
            using(CMSContext context=new CMSContext())
            {
                var article = context.Articles.AsNoTracking()
                                              .Where(a => a.ArticleId == articleId)
                                              .Select(x => new ArticleViewModel
                                              {
                                                  Title = x.Title,
                                                  Content = x.Content,
                                                  Description = x.Description,
                                                  PublishDate=x.PublishDate
                                              }).ToList();
                return article;
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
                        Description=x.Description,
                        Content = x.Content,
                    }).FirstOrDefault();

                article.CategoryIds = context.ArticleCategories.Where(s => s.ArticleId == articleId)
                                                                .Select(s => s.CategoryId)
                                                                .ToArray();
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
                    Description=model.Description,
                    PublishDate = DateTime.Now,
                    AuthorId = Guid.Parse("4417cb6e-89cf-4147-865d-e5362a283aa4")
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
        public bool Edit(EditArticleViewModel model, out string message)
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
                        data.Description = model.Description;
                        message = "";
                    }

                    var articleCategories = context.ArticleCategories.Where(a => a.ArticleId == model.ArticleId)
                                                                     .ToList();

                    var articleCategoryIds = articleCategories.Select(s => s.CategoryId)
                                                              .ToList();

                    if (articleCategories.Any())
                    {
                        if (model.CategoryIds.Any())
                        {
                            var mustBeDeletes = articleCategoryIds.Except(model.CategoryIds);
                            var mustBeAdds = model.CategoryIds.Except(articleCategoryIds);

                            if (mustBeDeletes.Any())
                            {
                                var mustBeDeletedCategory = articleCategories.Where(c => mustBeDeletes.Contains(c.CategoryId))
                                                                             .ToList();
                                if (mustBeDeletedCategory.Any())
                                {
                                    context.ArticleCategories.RemoveRange(mustBeDeletedCategory);
                                }
                            }
                            //foreach (var item in mustBeDelete)
                            //{
                            //    var mustBeDeletedCategory = context.ArticleCategories.Where(c => c.CategoryId == item).ToList();
                            //    foreach (var cat in mustBeDeletedCategory)
                            //    {
                            //        context.ArticleCategories.Remove(cat);
                            //    }
                            //    context.SaveChanges();
                            //}
                            if (mustBeAdds.Any())
                            {
                                foreach (var item in mustBeAdds)
                                {
                                    ArticleCategory obj = new ArticleCategory()
                                    {
                                        CategoryId = item,
                                        ArticleId = model.ArticleId
                                    };
                                    context.ArticleCategories.Add(obj);
                                }
                            }
                        }
                        else
                        {
                            var articles = context.ArticleCategories.Where(a => a.ArticleId == model.ArticleId).ToList();
                            if (articles.Any())
                            {
                                context.ArticleCategories.RemoveRange(articles);
                                ArticleCategory articleCategory = new ArticleCategory()
                                {
                                    ArticleId = model.ArticleId,
                                    CategoryId = 0
                                };
                                context.ArticleCategories.Add(articleCategory);
                            }
                        }
                        context.SaveChanges();
                        message = "";
                        return true;

                    }
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
