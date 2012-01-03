<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">
<div style="text-align:left">
新密码：&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><br />
确认密码：<asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
    <br />
</div>
<asp:Button runat="server" ID="btnChangePassword" Text = "确认" OnClick="btnChangePassword_Click" /><br />
    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" Runat="Server">
</asp:Content>

