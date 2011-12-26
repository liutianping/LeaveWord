using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OnlineLeaveWord.DAL.Blog.BlogImpl
{
    public class BlogOperationImpl : OnlineLeaveWord.DAL.Blog.BlogInterface.IBlogOperation
    {
        SqlCommand cmd = null;
        SqlConnection cn = null;
        Dictionary<string, object> parematers = null;
        private void CreateCommand(string strSql, Dictionary<string, object> paremater1)
        {
            cn = ConnectionService.GetInstance().GetConnection();
            cmd = new SqlCommand(strSql, cn);
            if (null != paremater1)
            {
                foreach (string key in paremater1.Keys)
                {
                    if (paremater1.ContainsKey(key))
                        cmd.Parameters.Add(new SqlParameter(key, paremater1[key]));
                }
            }
        }

        private List<OnlineLeaveWord.Model.Blog> GetBlogByDataReader(SqlDataReader sdr)
        {
            List<OnlineLeaveWord.Model.Blog> blogs = new List<OnlineLeaveWord.Model.Blog>();
            while (sdr.Read())
            {
                OnlineLeaveWord.Model.Blog blog = new OnlineLeaveWord.Model.Blog();
                blog.Id = int.Parse(sdr["id"].ToString());
                blog.Uid = sdr["uid"].ToString();
                blog.Blogtitle = sdr["blog_title"].ToString();
                blog.Publishtim = sdr["blog_publishtime"].ToString();
                blog.Lastupdatetime = sdr["blog_lastupdatetime"].ToString();
                blog.Blogcontent = sdr["blog_content"].ToString();
                blog.Blog_browercount = int.Parse(sdr["blog_browercount"].ToString());
                blog.Isdeleet = sdr["isdelete"].ToString();
                blogs.Add(blog);
            }
            sdr.Close();
            return blogs;
        }

        private void CloseConnection()
        {
            if (cn != null && cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
        #region IBlogOperation 成员

        public int GetCountByUserName(string userName)
        {
            string strSql = "SELECT count(id) FROM tb_blog where uid = @username";
            parematers = new Dictionary<string, object>();
            parematers.Add("username", userName);
            CreateCommand(strSql, parematers);
            string resultStr = cmd.ExecuteScalar().ToString();
            CloseConnection();
            return int.Parse(resultStr);
        }
        /// <summary>
        /// 查找某个时间段的所有博客
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="publishTime">时间段。传出入的格式是：2011_01</param>
        /// <returns></returns>
        public List<OnlineLeaveWord.Model.Blog> GetListByPublishTime(string userName, string publishTime)
        {
            string[] arrPublishTime = publishTime.Split(new char[] { '_' });
            string strSql = "select * from tb_blog where datepart(YEAR,[blog_publishtime])=@year and datepart(MONTH,[blog_publishtime])=@month and Uid=@username and isdelete=0";
            parematers = new Dictionary<string, object>();
            parematers.Add("@year", arrPublishTime[0]);
            parematers.Add("@month", arrPublishTime[1]);
            parematers.Add("@username", userName);
            CreateCommand(strSql, parematers);
            List<OnlineLeaveWord.Model.Blog> result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        public List<OnlineLeaveWord.Model.Blog> GetListByCategoryID(string userName, int id)
        {
            string strSql = "select * from tb_blog b join tb_blog_category c on b.id = c.blog_id where b.uid=@username and c.category_id = @id and isdelete=0";
            parematers = new Dictionary<string, object>();
            parematers.Add("@username", userName);
            parematers.Add("@id", id);
            CreateCommand(strSql, parematers);
            List<OnlineLeaveWord.Model.Blog> result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        public List<OnlineLeaveWord.Model.Blog> GetBlogDetail(int blogID)
        {
            string strSql = "select * from tb_blog where id = @id";
            parematers = new Dictionary<string, object>();
            parematers.Add("@id", blogID);
            CreateCommand(strSql, parematers);
            List<OnlineLeaveWord.Model.Blog> result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        public OnlineLeaveWord.Model.Blog GetBlogDetail(int blogID, int flag)
        {
            string strSql = "select * from tb_blog where id = @id";
            parematers = new Dictionary<string, object>();
            parematers.Add("@id", blogID);
            CreateCommand(strSql, parematers);
            List<OnlineLeaveWord.Model.Blog> result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            if (null != result)
                return result[0];
            else
                return null;
        }

        public int SaveBlog(OnlineLeaveWord.Model.Blog blog)
        {
            string strSql;
            int updateID = 0;//更新ID
            parematers = new Dictionary<string, object>();
            if (null != blog.Id)
            {
                strSql = "update tb_blog set uid=@username , blog_content=@blog_content,blog_title=@blog_title,blog_lastupdatetime=@blog_lastupdatetime where id=@id";
                parematers.Add("@id", blog.Id);
                updateID = blog.Id.Value;


            }
            else
            {
                strSql = "INSERT INTO tb_blog values(@username,@blog_content,@blog_title,@blog_publishtime,@blog_lastupdatetime,@blog_browercount,@isdelete)";
                parematers.Add("@isdelete", blog.Isdeleet);
                parematers.Add("@blog_publishtime", blog.Publishtim);
            }
            parematers.Add("@username", blog.Uid);
            parematers.Add("@blog_content", blog.Blogcontent);
            parematers.Add("@blog_title", blog.Blogtitle);
            parematers.Add("@blog_lastupdatetime", blog.Lastupdatetime);
            parematers.Add("@blog_browercount", blog.Blog_browercount);

            CreateCommand(strSql, parematers);
            cmd.ExecuteNonQuery();

            if (blog.Id == null)
            {
                cn = null;
                cmd = null;
                CreateCommand("select max(id) from tb_blog", null);
                int result = int.Parse(cmd.ExecuteScalar().ToString());
                CloseConnection();

                return result;
            }
            return updateID;
        }

        public int DeleteBlog(int blogID)
        {
            string strSql;
            OnlineLeaveWord.Model.Blog blog = GetBlogDetail(blogID, 0);
            if (null != blog)
            {
                if ("0" == blog.Isdeleet)
                {
                    strSql = "update tb_blog set isdelete=1 where id = @blogid";
                }
                else
                {
                    strSql = "update tb_blog set isdelete=2 where id = @blogid";
                }
            }
            else
                return 0;

            parematers = new Dictionary<string, object>();
            parematers.Add("@blogid", blogID);
            CreateCommand(strSql, parematers);
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }

        #endregion

        #region IBlogOperation 成员


        public List<OnlineLeaveWord.Model.Time_M> GetTimeListByUser(string userName)
        {
            List<OnlineLeaveWord.Model.Time_M> result = new List<OnlineLeaveWord.Model.Time_M>();
            string strSql = "select datepart(YEAR,[blog_publishtime]) as publishYear , " +
            "datepart(month,[blog_publishtime])as publishMonth ,COUNT(ID) as blogcount from tb_blog " +
            "where uid=@uid and isdelete=0" +
            "group by datepart(YEAR,[blog_publishtime]),datepart(month,[blog_publishtime]) " +
            "order by datepart(YEAR,[blog_publishtime]) desc,datepart(month,[blog_publishtime]) desc";
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", userName);
            CreateCommand(strSql, parematers);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                OnlineLeaveWord.Model.Time_M time = new OnlineLeaveWord.Model.Time_M();
                time.Year = dr["publishYear"].ToString();
                time.Month = dr["publishMonth"].ToString();
                time.Count = int.Parse(dr["blogcount"].ToString());
                result.Add(time);
            }
            dr.Close();
            CloseConnection();
            return result;
        }

        public void SaveBlogCategory(int blogID, List<int> listCategoryID)
        {
            parematers = new Dictionary<string, object>();
            string getBlogCategory = "select id from tb_blog_category where id =@blogid";
            parematers.Add("@blogid", blogID);
            CreateCommand(getBlogCategory, parematers);
            if (cmd.ExecuteReader().Read())
            {
                string strDelete = "DELETE from tb_blog_category where blog_id =@blogid";
                CreateCommand(strDelete, parematers);
                cmd.ExecuteNonQuery();
            }
            foreach (int var in listCategoryID)
            {

                string strSql = "Insert into tb_blog_category values(@id,@categoryid)";
                parematers.Clear();
                parematers.Add("@id", blogID);
                parematers.Add("@categoryid", var);
                CreateCommand(strSql, parematers);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public List<OnlineLeaveWord.Model.Blog> GetListTop(int top)
        {
            string strSql;
            if (top != -1)
                strSql = "select top " + top + " * from tb_blog where isdelete=0 order by blog_publishtime desc";
            else
                strSql = "select * from tb_blog where isdelete=0 order by blog_publishtime desc";
            CreateCommand(strSql, parematers);
            List<OnlineLeaveWord.Model.Blog> result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }
        public List<OnlineLeaveWord.Model.Blog> GetListByUser(string userName)
        {
            string strSql = "select * from tb_blog where uid = @id and isdelete=0";
            parematers = new Dictionary<string, object>();
            parematers.Add("@id", userName);
            CreateCommand(strSql, parematers);
            List<OnlineLeaveWord.Model.Blog> result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        public List<OnlineLeaveWord.Model.Blog> GetBlogCollectionList(string username)
        {
            List<OnlineLeaveWord.Model.Blog> result = new List<OnlineLeaveWord.Model.Blog>();
            string strSql = "SELECT * FROM tb_blog where uid=@username and isdelete=1";
            parematers = new Dictionary<string, object>();
            parematers.Add("@username", username);
            CreateCommand(strSql, parematers);
            result = GetBlogByDataReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        public void ReturnBlogStatus(int blogID)
        {
            string strSql = "update tb_blog set isdelete=0 where id=@id";
            parematers = new Dictionary<string, object>();
            parematers.Add("@id", blogID);
            CreateCommand(strSql, parematers);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion
    }
}
