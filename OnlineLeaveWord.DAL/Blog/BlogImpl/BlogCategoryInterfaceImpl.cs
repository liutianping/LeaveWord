using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OnlineLeaveWord.Model;


namespace OnlineLeaveWord.DAL.Blog.BlogImpl
{
    public class BlogCategoryInterfaceImpl : OnlineLeaveWord.DAL.Blog.BlogInterface.IBlogCategoryOperation
    {
        SqlConnection cn = null;
        SqlCommand cmd;
        Dictionary<string, object> parematers;
        #region IBlogCategoryOperation 成员

        public int BlogCategorySave(OnlineLeaveWord.Model.BlogCategory bc)
        {
            string strSql = "";
            parematers = new Dictionary<string, object>();
            if (bc.Id != 0) //更新操作
            {
                strSql = "update tb_category set categoryName=@categoryname , uId= @uid , publishTime=@publishtime , isdelete=@isdelete where id = @id";
                parematers.Add("@id", bc.Id);
            }
            else //插入操作
            {
                strSql = "Insert into tb_category values(@categoryname , @uid , @publishtime , @isdelete)";
            }
            parematers.Add("@categoryname", bc.CategoryName);
            parematers.Add("@uid", bc.UId);
            parematers.Add("@publishtime", bc.PublishTime);
            parematers.Add("@isdelete", bc.IsDelte);

            CreateCommand(cn, strSql);
            
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }

        public int BlogCategoryDelete(int bcId)
        {
            BlogCategory bc;
            parematers = new Dictionary<string, object>();
            parematers.Add("id", bcId);
            string strSql = "select isdelete from tb_category where id=@id";
            CreateCommand(cn, strSql);
            string state = cmd.ExecuteScalar().ToString();
            if (state == "0")//还没有删除过，此时要第一次删除，既将此Category放入回收站
            {
                bc = new BlogCategory();
                bc = GetBlogCategoryDetail(bcId);
                bc.IsDelte = "1";//第一次删除,更新isdelete 为 1 。表示第一次删除
                return BlogCategorySave(bc);
            }
            else if (state == "1")
            {
                bc = new BlogCategory();
                bc = GetBlogCategoryDetail(bcId);
                bc.IsDelte = "2";//第2次删除,更新isdelete 为 2 。表示将Category删除
                return BlogCategorySave(bc);
            }
            else //彻底删除
            {
                strSql = "delete from tb_category where id =@id";
                parematers.Clear();
                CreateCommand(cn, strSql);
                int result = cmd.ExecuteNonQuery();
                CloseConnection();
                return result;
            }
        }

        public List<OnlineLeaveWord.Model.BlogCategory> GetBlogCategoryListByUser(OnlineLeaveWord.Model.UserInfo_M u)
        {
            List<BlogCategory> result = new List<BlogCategory>();
            string strSql = "select * from tb_category where isdelete=0 and (uid = @uid or uid='systemDefault') ";
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", u.UID);
            CreateCommand(cn, strSql);
            result = GetBlogCategoryByDateReader(cmd.ExecuteReader(), 1);//1 是标志位，没有任何用处。
            CloseConnection();
            return result;
        }

        #endregion

        private void CreateCommand(SqlConnection cn2, string strSql)
        {
            cn = ConnectionService.GetInstance().GetConnection();
            cmd = new SqlCommand(strSql, cn);
            if (null != parematers)
            {
                foreach (string key in parematers.Keys)
                {
                    if (parematers.ContainsKey(key))
                        cmd.Parameters.AddWithValue(key, parematers[key]);
                }
            }
        }

        private BlogCategory GetBlogCategoryByDateReader(SqlDataReader dr)
        {
            BlogCategory result = new BlogCategory();
            while (dr.Read())
            {
                result.Id = int.Parse(dr["id"].ToString());
                result.CategoryName = dr["categoryName"].ToString();
                if (null != dr["uid"])
                    result.UId = dr["uid"].ToString();
                else
                    result.UId = "系统提供的默认值";
                result.PublishTime = dr["publishtime"].ToString();
                result.IsDelte = dr["isdelete"].ToString();
            }
            dr.Close();
            return result;
        }

        private List<BlogCategory> GetBlogCategoryByDateReader(SqlDataReader dr, int i)
        {
            List<BlogCategory> listResult = new List<BlogCategory>();

            while (dr.Read())
            {
                BlogCategory result = new BlogCategory();
                result.Id = int.Parse(dr["id"].ToString());
                result.CategoryName = dr["categoryName"].ToString();
                if (null != dr["uid"])
                    result.UId = dr["uid"].ToString();
                else
                    result.UId = "系统提供的默认值";
                result.PublishTime = dr["publishtime"].ToString();
                result.IsDelte =dr["isdelete"].ToString();
                listResult.Add(result);

            }
            dr.Close();
            return listResult;
        }

        private void CloseConnection()
        {
            if (cn != null)
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        cn.Close();
                    }
                    catch (Exception)
                    {
                        //TODO 记录日志  关闭连接失败。位置：BlogCategoryinterfaceImpl 79行                    Cate
                    }
                }
            }
        }


        #region IBlogCategoryOperation 成员


        public BlogCategory GetBlogCategoryDetail(int bcId)
        {
            BlogCategory result = new BlogCategory();
            string strSql = "select * from tb_category where id = @id";
            parematers = new Dictionary<string, object>();
            parematers.Add("@id", bcId);
            CreateCommand(cn, strSql);
            result = GetBlogCategoryByDateReader(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        #endregion

        #region IBlogCategoryOperation 成员


        public int ReturnCategory(int bcId)
        {
            string strSql = "update tb_category set isDelete=0 where id = @id";
            parematers.Add("@id", bcId);
            CreateCommand(cn, strSql);
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }

        #endregion

        #region IBlogCategoryOperation 成员

        /// <summary>
        /// 查找已经删除的类别
        /// </summary>
        /// <param name="u">用户名</param>
        /// <param name="flag">标记位，固定为1</param>
        /// <returns></returns>
        public List<BlogCategory> GetBlogCategoryListByUser(UserInfo_M u, int flag)
        {
            List<BlogCategory> result = new List<BlogCategory>();
            string strSql = "select * from tb_category where uid = @uid and isdelete=1";
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", u.UID);
            CreateCommand(cn, strSql);
            result = GetBlogCategoryByDateReader(cmd.ExecuteReader(), 1);//1 是标志位，没有任何用处。
            CloseConnection();
            return result;
        }

        #endregion

        #region IBlogCategoryOperation 成员


        public List<BlogCategory> GetBlogCategoryByBlogId(int blogID)
        {
            List<BlogCategory> result = new List<BlogCategory>();
            string strSql = "SELECT * FROM tb_category a join tb_blog_category b on a.id = b.category_id where b.blog_id=@blogid and isdelete = 0";
            parematers = new Dictionary<string, object>();
            parematers.Add("@blogid",blogID);
            CreateCommand(null,strSql);
            result = GetBlogCategoryByDateReader(cmd.ExecuteReader(),1);
            CloseConnection();
            return result;
        }

        #endregion
    }
}
