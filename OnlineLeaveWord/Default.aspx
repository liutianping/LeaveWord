<%@ Page Language="C#" MasterPageFile="~/LeaveWord_N.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    最新博客<asp:Repeater runat="server" ID="rptNewBlog">
        <ItemTemplate>
            <div>
                <%# GetString(Container.DataItem)%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div style="text-align: right">
        更多...</div>
    
</asp:Content>

