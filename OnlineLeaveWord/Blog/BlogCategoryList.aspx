<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogCategoryList.aspx.cs"
    Inherits="Blog_BlogCategoryList" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <div style="text-align:left">
        <h2>我的类别</h2></div>
    <div>
        <div style="border: solid 1px white; width: 250px; margin-left: 5px; text-align: center">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <div style="text-align: left; margin-left: 15px; border: solid 1px white">
                        <a href='BlogListByCategoryID.aspx?ctegoryid=<%# Eval("categoryname") %>'>
                            <%# Eval("categoryname")%>
                        </a>&nbsp;
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
</asp:Content>
