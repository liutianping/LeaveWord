<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="BlogCollection.aspx.cs" Inherits="Blog_BlogCollection" Title="博客回收站" %>

<%@ Register Src="../UserControls/BlogCollection.ascx" TagName="BlogCollection" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">
    
    <uc1:BlogCollection id="BlogCollection1" runat="server">
    </uc1:BlogCollection>
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" Runat="Server">
</asp:Content>

