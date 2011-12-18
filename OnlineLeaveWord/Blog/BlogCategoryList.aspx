<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogCategoryList.aspx.cs" EnableEventValidation="false"
    Inherits="Blog_BlogCategoryList" Title="" %>

<%@ Register Src="../UserControls/UC_BlogCategoryCollection.ascx" TagName="UC_BlogCollection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <div style="text-align: left">
        <h2>
            我的类别</h2>
    </div>
    <div>
        <div style="margin-left: 5px; text-align: center">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <div style="text-align: left; margin-left: 15px; border: solid 1px white">
                        <a href='BlogListByCategoryID.aspx?ctegoryid=<%# Eval("id") %>'>
                            <%# Eval("categoryname")%>(<%# GetBlogCountByCategoryID(Eval("id"))%>)
                        </a>&nbsp;
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
    <div>
        <h4>
            类别回收站
        </h4>
       
        <uc1:UC_BlogCollection ID="UC_BlogCollection1" runat="server"></uc1:UC_BlogCollection>
    </div>
</asp:Content>
