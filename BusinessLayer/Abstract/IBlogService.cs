using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService: IGenericService<Blog>
    {
        int TotalBlogCount();
        int TotalBlogCountByWriterId(int id);
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
        List<Blog> GetAll(int id);
        List<Blog> GetBlogsWithWriterId(int writerId);
        
    }
}
