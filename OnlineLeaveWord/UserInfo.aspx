<%@ Page Language="C#" MasterPageFile="~/LeaveWord.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">

<div style="text-align:left">
用户名: &nbsp;
    <asp:TextBox runat="server" ID="txtUserInfo"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserInfo"
        ErrorMessage="*">用户名不能为空</asp:RequiredFieldValidator><br />
性别:
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Value="1">男</asp:ListItem>
    <asp:ListItem Value="2">女</asp:ListItem>
    </asp:RadioButtonList>
E-mail: &nbsp;
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
QQ: &nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtQQ" runat="server"></asp:TextBox><br />
个人主页:
    <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox><br />
   
</div>
    <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
</asp:Content>

