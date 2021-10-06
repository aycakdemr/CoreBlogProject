using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _NewsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _NewsLetterDal = newsLetterDal;
        }

        public void Add(NewsLetter newsLetter)
        {
            _NewsLetterDal.Insert(newsLetter);
        }

        public void Delete(NewsLetter newsLetter)
        {
            _NewsLetterDal.Delete(newsLetter);
        }

        public List<NewsLetter> GetAll()
        {
            return _NewsLetterDal.GetAll();
        }

        public NewsLetter GetById(int id)
        {
            return _NewsLetterDal.GetById(id);
        }

        public void Update(NewsLetter newsLetter)
        {
            _NewsLetterDal.Update(newsLetter);
        }
    }
}
