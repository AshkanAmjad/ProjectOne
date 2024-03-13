using Domain.Data.Context;
using Domain.Entites.Portal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models.Category;

namespace Bussiness.Portal
{
    public class CategoryServices
    {

        public List<CategoryViewModel> GetCategories()
        {
            using (CMSContext context = new CMSContext())
            {
                var users = context.Categories.AsNoTracking()
                                        .Select(x => new CategoryViewModel
                                        {
                                            CategoryId = x.CategoryId,
                                            Title = x.Title,
                                            IsActive = x.IsActive
                                        }).ToList();
                return users;
            }
        }
        public IQueryable<Category> GetCategoriesQuery()
        {
            using(CMSContext context = new CMSContext())
            {
                return context.Categories.AsQueryable();
            }
        }
        public bool Similarity(string title,int categoryId ,out string message)
        {
            using (CMSContext context = new CMSContext())
            {
                bool checkTitle = context.Categories.Where(c => c.Title == title && c.CategoryId != categoryId).Any();
                if (checkTitle == true)
                {
                    message = "Duplicated Title";
                    return checkTitle;
                }

                message = "";
                return false;
            }
        }
        public bool Add(CategoryViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity(model.Title, model.CategoryId, out checkMessage) == false)
            {
                Category category = new Category()
                {
                    Title = model.Title,
                    IsActive = model.IsActive
                };
                using (CMSContext context = new CMSContext())
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
                message = "";
                return true;
            }
            message = checkMessage;
            return false;
        }
        public bool Edit(CategoryViewModel model, out string message)
        {
            string checkMessage = "";
            if (Similarity(model.Title, model.CategoryId, out checkMessage) == false)
            {
                using (CMSContext context = new CMSContext())
                {
                    var data = context.Categories.Where(a => a.CategoryId == model.CategoryId).FirstOrDefault();
                    if (data != null)
                    {
                        data.Title = model.Title;
                        data.IsActive = model.IsActive;
                        context.SaveChanges();
                        message = "";
                        return true;
                    }
                }
            }
            message = checkMessage;
            return true;
        }
        public bool Delete(CategoryViewModel model)
        {
            using (CMSContext context = new CMSContext())
            {
                var data = context.Categories.Where(c => c.CategoryId == model.CategoryId && c.IsActive == true).FirstOrDefault();
                if (data != null)
                {
                    context.Categories.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
