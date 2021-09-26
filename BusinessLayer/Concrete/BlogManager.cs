﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAll(int id)
        {
            return _blogDal.GetAll(x => x.BlogId == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
