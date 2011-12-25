<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="BlogAdd.aspx.cs"
    Inherits="BlogAdd" Title="Untitled Page" %>

<%@ Register Src="../UserControls/UC_BlogListByPublishTime.ascx" TagName="UC_BlogListByPublishTime"
    TagPrefix="uc2" %>

<%@ Register Src="../UserControls/BlogManagerMenu.ascx" TagName="BlogManagerMenu"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="dntb" Namespace="DotNetTextBox" Assembly="DotNetTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <div id="divBlogManagerMenu" style="text-align: left">
        <asp:Label ID="Label1" runat="server" Text="博客标题:"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="博客内容:"></asp:Label>
        <dntb:WebEditor ID="txtBlogContent" runat="server" Width="580px"></dntb:WebEditor>
        
        <asp:Label ID="Label3" runat="server" Text="博客类别:"></asp:Label><br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5">
        </asp:CheckBoxList></div>
    <asp:Button ID="btnTrue" runat="server" Text="确定" OnClick="btnTrue_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
    &nbsp;
</asp:Content>
