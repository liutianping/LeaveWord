using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.BLL.Blog.BlogInterface
{
    public interface IBlogCategoryOperation
    {
        int BlogCategorySave(BlogCategory bc);
        int BlogCategoryDelete(int bcId);
        List<BlogCategory> GetBlogCategoryListByUser(UserInfo_M u);
        BlogCategory GetBlogCategoryDetail(int bcId);
        int ReturnCategory(int bcId);
    }
}