<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" CodeFile="UpdateBlog.aspx.cs" ValidateRequest="false"
    Inherits="Blog_UpdateBlog" Title="Untitled Page" %>

<%@ Register TagPrefix="dntb" Namespace="DotNetTextBox" Assembly="DotNetTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
location.href="BlogManager.aspx";
}

// ]]>
    </script>

    <div style="text-align: left">
        <asp:Label ID="Label1" runat="server" Text="博客标题:"></asp:Label>
        <asp:TextBox ID="txtBlogTitle" runat="server"></asp:TextBox><br />
        正文:<br />
        <dntb:WebEditor ID="txtBlogContent" runat="server" Width="580px"></dntb:WebEditor>
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5">
        </asp:CheckBoxList>&nbsp;
    </div>
    <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" />
    <input id="Button2" type="button" value="返回" onclick="return Button2_onclick()" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" runat="Server">
    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>
