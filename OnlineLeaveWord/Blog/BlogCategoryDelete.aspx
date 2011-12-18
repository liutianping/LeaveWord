<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogCategoryDelete.aspx.cs" Inherits="Blog_BlogCategoryDelete" Title="删除博客类别" %>

<%@ Register Src="../UserControls/UC_BlogCategoryCollection.ascx" TagName="UC_BlogCollection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">
   <div>
   <h4>类别操作</h4>
           <asp:GridView ID="GridView1" runat="server" Width="291px">
           </asp:GridView>

   </div>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" Runat="Server">
    类别回收站:<br />
    <div style="text-align:left;"><uc1:UC_BlogCollection ID="UC_BlogCollection1" runat="server" />
        &nbsp;</div>
  
</asp:Content>

