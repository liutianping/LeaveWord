<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Login.ascx.cs" Inherits="UserControls_UC_Login" %>
<div style="text-align: center">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 286px; height: 90px">
        <tr>
            <td style="width: 100px; text-align: right">
                &nbsp;<asp:Label ID="lblUserName" runat="server" Text="用户名:"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right">
                <asp:Label ID="lblPassword" runat="server" Text="密码:"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 15px; text-align: center">
                <asp:Button ID="btnLogin" runat="server" Text=" 登 录 " OnClick="btnLogin_Click" />
                <asp:Button ID="btnReNew" runat="server" Text=" 重 置 " /></td>
        </tr>
    </table>
</div>
