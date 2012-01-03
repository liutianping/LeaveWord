using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;
using OnlineLeaveWord;

public partial class _Default : System.Web.UI.Page
{
    OAuthBase oAuth = new OAuthBase();
    string apiKey = "786050791";//申请的App Key
    string apiKeySecret = "e5e125438b0bb136919524ce633f16d8";//申请的App Secret
    string requestTokenUri = "http://api.t.sina.com.cn/oauth/request_token";
    string AUTHORIZE = "http://api.t.sina.com.cn/oauth/authorize";
    string ACCESS_TOKEN = "http://api.t.sina.com.cn/oauth/access_token";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["oauth_verifier"]))
        {
            string abc = Request["oauth_verifier"].ToString();
            string bcd = Request["oauth_token"].ToString();
            getAccessToken(Request["oauth_token"].ToString(), Request["oauth_verifier"].ToString());
        }
        else
        {
            ImageButton1.Visible = true;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        getRequestToken();
    }
    public void getAccessToken(string requestToken, string oauth_verifier)
    {
        Uri uri = new Uri(ACCESS_TOKEN);
        string nonce = oAuth.GenerateNonce();
        string timeStamp = oAuth.GenerateTimeStamp();
        string normalizeUrl, normalizedRequestParameters;
        // 签名
        string sig = oAuth.GenerateSignature(
        uri,
        apiKey,
        apiKeySecret,
        requestToken,
        Session["oauth_token_secret"].ToString(),
        "Get",
        timeStamp,
        nonce,
        oauth_verifier,
        out normalizeUrl,
        out normalizedRequestParameters);
        sig = oAuth.UrlEncode(sig);
        //构造请求Access Token的url
        StringBuilder sb = new StringBuilder(uri.ToString());
        sb.AppendFormat("?oauth_consumer_key={0}&", apiKey);
        sb.AppendFormat("oauth_nonce={0}&", nonce);
        sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
        sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
        sb.AppendFormat("oauth_version={0}&", "1.0");
        sb.AppendFormat("oauth_signature={0}&", sig);
        sb.AppendFormat("oauth_token={0}&", requestToken);
        sb.AppendFormat("oauth_verifier={0}", oauth_verifier);
        //请求Access Token
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
        string responseBody = stream.ReadToEnd();
        stream.Close();
        response.Close();
        int intOTS = responseBody.IndexOf("oauth_token=");
        int intOTSS = responseBody.IndexOf("&oauth_token_secret=");
        int intUser = responseBody.IndexOf("&user_id=");
        Session["oauth_token"] = responseBody.Substring(intOTS + 12, intOTSS - (intOTS + 12));
        Session["oauth_token_secret"] = responseBody.Substring((intOTSS + 20), intUser - (intOTSS + 20));
        Session["User_Id"] = responseBody.Substring((intUser + 9), responseBody.Length - (intUser + 9));
        verify_credentials();
    }

    public void verify_credentials()
    {
        Uri uri = new Uri("http://api.t.sina.com.cn/account/verify_credentials.xml");
        string nonce = oAuth.GenerateNonce();
        string timeStamp = oAuth.GenerateTimeStamp();
        string normalizeUrl, normalizedRequestParameters;
        // 签名
        string sig = oAuth.GenerateSignature(
        uri,
        apiKey,
        apiKeySecret,
        Session["oauth_token"].ToString(),
        Session["oauth_token_secret"].ToString(),
        "Get",
        timeStamp,
        nonce,
        string.Empty,
        out normalizeUrl,
        out normalizedRequestParameters);
        sig = HttpUtility.UrlEncode(sig);
        StringBuilder sb = new StringBuilder(uri.ToString());
        sb.AppendFormat("?oauth_consumer_key={0}&", apiKey);
        sb.AppendFormat("oauth_nonce={0}&", nonce);
        sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
        sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
        sb.AppendFormat("oauth_version={0}&", "1.0");
        sb.AppendFormat("oauth_signature={0}&", sig);
        sb.AppendFormat("oauth_token={0}&", Session["oauth_token"].ToString());
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
        string responseBody = stream.ReadToEnd();
        stream.Close();
        response.Close();
        //Session["responseBody"] = responseBody;//用户个人信息在这个里面了！！
        GetUserInfo(responseBody);
        //"<?xml version=\"1.0\" encoding=\"UTF-8\"?><user><id>1918422547</id>
        //<screen_name>ltp2010</screen_name>
        //<name>ltp2010</name>
        //<province>44</province><city>1</city>
        //<location>广东 广州</location><description></description><url></url><profile_image_url>http://tp4.sinaimg.cn/1918422547/50/0/1</profile_image_url><domain></domain><gender>m</gender><followers_count>3</followers_count><friends_count>25</friends_count><statuses_count>46</statuses_count><favourites_count>0</favourites_count><created_at>Tue Jan 11 00:00:00 +0800 2011</created_at><following>false</following><verified>false</verified><allow_all_act_msg>false</allow_all_act_msg><geo_enabled>false</geo_enabled><status><created_at>Tue Dec 20 00:24:17 +0800 2011</created_at><id>3392472183122369</id><text>曾经的承诺，只是一纸空文，而我多想去实现。</text><source><a href=\"http://weibo.com\">新浪微博</a></source><favorited>false</favorited><truncated>false</truncated><geo/><in_reply_to_status_id></in_reply_to_status_id><in_reply_to_user_id></in_reply_to_user_id><in_reply_to_screen_name></in_repl
        //  y_to_screen_name><mid>3392472183122369</mid></status></user>"
        //
        Response.Redirect("Default.aspx");//成功后跳转到的页面
    }

    private void GetUserInfo(string xmlStr)
    {
        int startIndex = xmlStr.IndexOf("<name>");
        int endIndex = xmlStr.IndexOf("</name>");
        string userName = xmlStr.Substring(startIndex, endIndex - startIndex);
        Session["username"] = userName;
    }

    private void getRequestToken()
    {
        Uri uri = new Uri(requestTokenUri);
        string nonce = oAuth.GenerateNonce();//获取随机生成的字符串，防止攻击
        string timeStamp = oAuth.GenerateTimeStamp();//发起请求的时间戳
        string normalizeUrl, normalizedRequestParameters;
        // 签名
        string sig = oAuth.GenerateSignature(uri, apiKey, apiKeySecret, string.Empty, string.Empty, "GET", timeStamp, nonce, string.Empty, out normalizeUrl, out normalizedRequestParameters);
        sig = HttpUtility.UrlEncode(sig);
        //构造请求Request Token的url
        StringBuilder sb = new StringBuilder(uri.ToString());
        sb.AppendFormat("?oauth_consumer_key={0}&", apiKey);
        sb.AppendFormat("oauth_nonce={0}&", nonce);
        sb.AppendFormat("oauth_signature={0}&", sig);
        sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
        sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
        sb.AppendFormat("oauth_version={0}", "1.0");
        //请求Request Token
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
        string responseBody = stream.ReadToEnd();
        stream.Close();
        response.Close();
        int intOTS = responseBody.IndexOf("oauth_token=");
        int intOTSS = responseBody.IndexOf("&oauth_token_secret=");
        Session["oauth_token"] = responseBody.Substring(intOTS + 12, intOTSS - (intOTS + 12));
        Session["oauth_token_secret"] = responseBody.Substring((intOTSS + 20), responseBody.Length - (intOTSS + 20));
        Response.Redirect(AUTHORIZE + "?oauth_token=" + Session["oauth_token"] + "&oauth_callback=" + Request.Url);
    }
}
