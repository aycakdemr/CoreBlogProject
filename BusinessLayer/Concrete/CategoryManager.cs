using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository cr;

        public CategoryManager(EfCategoryRepository cr)
        {
            this.cr = cr;
        }

        public void Add(Category category)
        {
            if (category.CategoryName != "" && category.CategoryDescription != "")
            {
                cr.Insert(category);
            }
            else
            {

            }
        }

        public void Delete(Category category)
        {
            cr.Delete(category);

        }

        public List<Category> GetAll()
        {
            return cr.GetAll();
        }

        public Category GetById(int id)
        {
            return cr.GetById(id);
        }

        public void Update(Category category)
        {
            cr.Update(category);
        }
    }
}
