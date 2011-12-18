<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="BlogCategoryAdd.aspx.cs"
    Inherits="BlogCategoryAdd" Title="添加博客类别" %>

<%@ Register Src="../UserControls/UC_BlogCategoryCollection.ascx" TagName="UC_BlogCollection"
    TagPrefix="uc3" %>
<%@ Register Src="../UserControls/BlogManagerMenu.ascx" TagName="BlogManagerMenu"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/UC_BlogMenu.ascx" TagName="UC_BlogMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <div style="text-align: left; margin-left: 10%; margin-top: 5px">
        <div style="text-align: left">
            添加博客类别:</div>
        <asp:Label ID="lblCategoryName" runat="server" Text="类别名字:"></asp:Label>
        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSure" runat="server" Text="确定" OnClick="btnSure_Click" /><br />
        <hr style="width: 90%" />
        <br />
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <div>
                    <a href='BlogListByCategoryID.aspx?ctegoryid=<%# Eval("id") %>'>
                        <%# Eval("categoryname")%>
                        (<%# GetBlogCountByCategoryID(Eval("id"))%>) </a>&nbsp;
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
    <div>
        <h4>
            类别回收站
        </h4>
        <uc3:UC_BlogCollection ID="UC_BlogCollection1" runat="server" />
       
       
    </div>
</asp:Content>
