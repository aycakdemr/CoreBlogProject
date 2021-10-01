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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetAll(int id)
        {
            return _commentDal.GetAll(x=>x.BlogId ==id);
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
