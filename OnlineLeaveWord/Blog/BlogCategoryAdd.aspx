<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogCategoryAdd.aspx.cs"
    Inherits="BlogCategoryAdd" Title="添加博客类别" %>

<%@ Register Src="../UserControls/BlogManagerMenu.ascx" TagName="BlogManagerMenu"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/UC_BlogMenu.ascx" TagName="UC_BlogMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <div style="text-align: left">
        <div style="text-align: left">
            添加博客类别:</div>
        <asp:Label ID="lblCategoryName" runat="server" Text="类别名字:"></asp:Label>
        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSure" runat="server" Text="确定" OnClick="btnSure_Click" /><br />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
    已删除类别:<br />
    44
</asp:Content>
