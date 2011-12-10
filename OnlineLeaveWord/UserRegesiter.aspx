<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegesiter.aspx.cs" Inherits="UserRegesiter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="style/index.css" rel="Stylesheet" />
    <title>用户注册</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="images/top_backgroup.png" style="width: 920px" /><br />
        </div>
        <div style="margin-left:250px;text-align:left">
        用户名:&nbsp;
            <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>&nbsp
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUserName">用户名为必填项</asp:RequiredFieldValidator></div>
        <div style="margin-left:250px;text-align:left">
        密码: &nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>&nbsp
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码为必填项" ControlToValidate="txtPassword">密码为必填项</asp:RequiredFieldValidator></div>
        <div style="margin-left:250px;text-align:left">
        确认密码:<asp:TextBox runat="server" ID="txtConfirmPassword"></asp:TextBox>&nbsp
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" ErrorMessage="*">两次输入的密码不一致</asp:CompareValidator></div>
        <div style="margin-left:250px;text-align:left">
            性别: &nbsp;&nbsp;
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" Text="男" Checked="True" />&nbsp;
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="1" Text="女" />
        </div>
        <div style="margin-left:250px;text-align:left">
        个人主页:<asp:TextBox runat="server" ID="txtWebsite"></asp:TextBox>&nbsp
        </div>
        <div style="margin-left:250px;text-align:left">
        Email: &nbsp; &nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>&nbsp
        </div>
        <div style="margin-left:250px;text-align:left">
        QQ: &nbsp; &nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>&nbsp
        </div>
        
        <div>
            <asp:Button runat="server" ID="btnSure" Text="确定" OnClick="btnSure_Click"/>
            <asp:Button runat = "server" ID="btnReturn" Text="返回"/>
        </div>
    </form>
</body>
</html>
