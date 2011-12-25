<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogListByUser.aspx.cs"
    Inherits="Blog_BlogListByUser" Title="Untitled Page" %>

<%@ Register Src="../UserControls/UC_BlogListByPublishTime.ascx" TagName="UC_BlogListByPublishTime"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div>
                <%# GetString(Container.DataItem)%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
    <uc1:UC_BlogListByPublishTime ID="UC_BlogListByPublishTime1" runat="server" />
</asp:Content>
