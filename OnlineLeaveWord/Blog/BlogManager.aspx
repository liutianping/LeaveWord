<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BlogManager.aspx.cs"
    Inherits="Blog_BlogManager" Title="博客管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div>
                <a href='../Blog/BlogDetail.aspx?blogid=<%# Eval("id") %>'>
                    <%# SubString(Eval("blogcontent").ToString())%>
                </a>
                
                <asp:ImageButton ID="imgUpdate" runat="server"
                    CommandArgument='<%# Eval("id") %>' ImageUrl="~/images/edit.gif" PostBackUrl="~/Blog/UpdateBlog.aspx"/>
                <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('11111111')"
                    CommandArgument='<%# Eval("id") %>' ImageUrl="~/images/-.gif" OnClick="ImgDelete_Click" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Label ID="Label1" runat="server" Visible="false" Text="Label"></asp:Label>
    <asp:LinkButton PostBackUrl="~/Blog/BlogAdd.aspx" Visible="false" ID="linkBlogAdd"
        runat="server" Text="发表博客-->"></asp:LinkButton>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
</asp:Content>
