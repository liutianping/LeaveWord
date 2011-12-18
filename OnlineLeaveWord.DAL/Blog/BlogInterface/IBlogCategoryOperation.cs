using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.DAL.Blog.BlogInterface
{
    public interface IBlogCategoryOperation
    {
        int BlogCategorySave(BlogCategory bc);
        int BlogCategoryDelete(int bcId);
        List<BlogCategory> GetBlogCategoryListByUser(UserInfo_M u);
        List<BlogCategory> GetBlogCategoryListByUser(UserInfo_M u,int flag);
        BlogCategory GetBlogCategoryDetail(int bcId);
        int ReturnCategory(int bcId);
    }
}
