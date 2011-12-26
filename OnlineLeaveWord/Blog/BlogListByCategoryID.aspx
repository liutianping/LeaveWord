<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogListByCategoryID.aspx.cs" Inherits="Blog_BlogListByCategoryID" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">
  <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div>
                <%# GetString(Container.DataItem)%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" Runat="Server">
</asp:Content>

