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
        #region IBlogCategoryOperation ��Ա

        public int BlogCategorySave(OnlineLeaveWord.Model.BlogCategory bc)
        {
            string strSql = "";
            parematers = new Dictionary<string, object>();
            if (bc.Id != 0) //���²���
            {
                strSql = "update tb_category set categoryName=@categoryname , uId= @uid , publishTime=@publishtime , isdelete=@isdelete where id = @id";
                parematers.Add("@id", bc.Id);
            }
            else //�������
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
            if (state == "0")//��û��ɾ��������ʱҪ��һ��ɾ�����Ƚ���Category�������վ
            {
                bc = new BlogCategory();
                bc = GetBlogCategoryDetail(bcId);
                bc.IsDelte = "1";//��һ��ɾ��,����isdelete Ϊ 1 ����ʾ��һ��ɾ��
                return BlogCategorySave(bc);
            }
            else if (state == "1")
            {
                bc = new BlogCategory();
                bc = GetBlogCategoryDetail(bcId);
                bc.IsDelte = "2";//��2��ɾ��,����isdelete Ϊ 2 ����ʾ��Categoryɾ��
                return BlogCategorySave(bc);
            }
            else //����ɾ��
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
            result = GetBlogCategoryByDateReader(cmd.ExecuteReader(), 1);//1 �Ǳ�־λ��û���κ��ô���
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
                    result.UId = "ϵͳ�ṩ��Ĭ��ֵ";
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
                    result.UId = "ϵͳ�ṩ��Ĭ��ֵ";
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
                        //TODO ��¼��־  �ر�����ʧ�ܡ�λ�ã�BlogCategoryinterfaceImpl 79��                    Cate
                    }
                }
            }
        }


        #region IBlogCategoryOperation ��Ա


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

        #region IBlogCategoryOperation ��Ա


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

        #region IBlogCategoryOperation ��Ա

        /// <summary>
        /// �����Ѿ�ɾ�������
        /// </summary>
        /// <param name="u">�û���</param>
        /// <param name="flag">���λ���̶�Ϊ1</param>
        /// <returns></returns>
        public List<BlogCategory> GetBlogCategoryListByUser(UserInfo_M u, int flag)
        {
            List<BlogCategory> result = new List<BlogCategory>();
            string strSql = "select * from tb_category where uid = @uid and isdelete=1";
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", u.UID);
            CreateCommand(cn, strSql);
            result = GetBlogCategoryByDateReader(cmd.ExecuteReader(), 1);//1 �Ǳ�־λ��û���κ��ô���
            CloseConnection();
            return result;
        }

        #endregion

        #region IBlogCategoryOperation ��Ա


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
