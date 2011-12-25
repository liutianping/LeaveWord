using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl;

namespace OnlineLeaveWord.BLL.Blog.BlogInterface
{
    public class BlogOperationBLL : IBlogOperationBLL
    {
        OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl blogOperation = null;
        #region IBlogOperationBLL ≥…‘±

        public int GetCountByUserName(string userName)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetCountByUserName(userName);
        }

        public List<OnlineLeaveWord.Model.Blog> GetListByPublishTime(string username, string publishTime)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetListByPublishTime(username, publishTime);
        }

        public List<OnlineLeaveWord.Model.Blog> GetListByCategoryID(string username, int id)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetListByCategoryID(username, id);
        }

        public List<OnlineLeaveWord.Model.Blog> GetBlogDetail(int blogID)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetBlogDetail(blogID);
        }

        public int SaveBlog(OnlineLeaveWord.Model.Blog blog)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.SaveBlog(blog);
        }

        public int DeleteBlog(int blogID)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.DeleteBlog(blogID);
        }

        public List<OnlineLeaveWord.Model.Time_M> GetTimeListByUser(string userName)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetTimeListByUser(userName);
        }

        public void SaveBlogCategory(int blogID, List<int> listCategoryID)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            blogOperation.SaveBlogCategory(blogID, listCategoryID);
        }

        public List<OnlineLeaveWord.Model.Blog> GetListByUser(string userName)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetListByUser(userName);
        }

        public List<OnlineLeaveWord.Model.Blog> GetBlogCollectionList(string username)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            return blogOperation.GetBlogCollectionList(username);
        }

        public void ReturnBlogStatus(int blogID)
        {
            blogOperation = new OnlineLeaveWord.DAL.Blog.BlogImpl.BlogOperationImpl();
            blogOperation.ReturnBlogStatus(blogID);
        }

        #endregion
    }
}
