using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.BLL.Blog.BlogInterface;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl
{
   public class BlogCategoryImpl : IBlogCategoryOperation
    {
       OnlineLeaveWord.DAL.Blog.BlogInterface.IBlogCategoryOperation bcOperation = null;
        #region IBlogCategoryOperation ≥…‘±

        public int BlogCategorySave(BlogCategory bc)
        {
            bcOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogCategoryInterfaceImpl();
            return bcOperation.BlogCategorySave(bc);
        }

        public int BlogCategoryDelete(int bcId)
        {
            bcOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogCategoryInterfaceImpl();
            return bcOperation.BlogCategoryDelete(bcId);
        }

        public List<BlogCategory> GetBlogCategoryListByUser(UserInfo_M u)
        {
            bcOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogCategoryInterfaceImpl();
            return bcOperation.GetBlogCategoryListByUser(u);
        }

        public BlogCategory GetBlogCategoryDetail(int bcId)
        {
            bcOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogCategoryInterfaceImpl();
            return bcOperation.GetBlogCategoryDetail(bcId);
        }

        public int ReturnCategory(int bcId)
        {
            bcOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogCategoryInterfaceImpl();
            return bcOperation.ReturnCategory(bcId);
        }

        #endregion
    }
}
