using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        ICategoryDal _categoryDal;

        public CategoryManager(EfCategoryRepository cr)
        {
            this._categoryDal = cr;
        }

        public void Add(Category category)
        {
            if (category.CategoryName != "" && category.CategoryDescription != "")
            {
                _categoryDal.Insert(category);
            }
            else
            {

            }
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);

        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
