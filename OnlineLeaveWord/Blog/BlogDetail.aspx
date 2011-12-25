<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogDetail.aspx.cs" Inherits="Blog_BlogDetail" Title="博客详情" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">
    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
    <p style="text-align:left">正文:</p>
    
    <div style="width:450px;text-align:left">
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
    </div>
    
    <div style="text-align:right;vertical-align:bottom">
        类别:
        <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblCount" runat="server" Text="Label">
        </asp:Label>
        
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" Runat="Server">
</asp:Content>

