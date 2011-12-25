using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl
{
     interface IBlogOperationBLL
    {
        int GetCountByUserName(string userName);
        List<OnlineLeaveWord.Model.Blog> GetListByPublishTime(string username, string publishTime);
        List<OnlineLeaveWord.Model.Blog> GetListByCategoryID(string username, int id);
        List<OnlineLeaveWord.Model.Blog> GetBlogDetail(int blogID);
        int SaveBlog(OnlineLeaveWord.Model.Blog blog);
        int DeleteBlog(int blogID);
         List<OnlineLeaveWord.Model.Time_M> GetTimeListByUser(string userName);
         void SaveBlogCategory(int blogID, List<int> listCategoryID);
         List<OnlineLeaveWord.Model.Blog> GetListByUser(string userName);
         List<OnlineLeaveWord.Model.Blog> GetBlogCollectionList(string username);
         void ReturnBlogStatus(int blogID);
    }
}
