using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.DAL.Blog.BlogInterface
{
    public interface IBlogOperation
    {
        int GetCountByUserName(string userName);
        List<OnlineLeaveWord.Model.Blog> GetListByPublishTime(string publishTime);
        List<OnlineLeaveWord.Model.Blog> GetListByCategoryID(int id);
        List<OnlineLeaveWord.Model.Blog> GetBlogDetail(int blogID);
        int SaveBlog(OnlineLeaveWord.Model.Blog blog);
        int DeleteBlog(int blogID);

    }
}
