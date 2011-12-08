<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="LeaveWord.aspx.cs" Inherits="LeaveWord" Title="发表留言" %>

<%@ Register TagPrefix="dntb" Namespace="DotNetTextBox" Assembly="DotNetTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divLeaveWordContent" style="width:auto">
        <div style="width: auto; height: auto; text-align: left">
            留言主题:
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </div>
        <div style="width: auto; height: auto; text-align: left;">
            留言内容:</div>
        <div style="width: auto; height: auto; text-align: left;">
            <dntb:WebEditor ID="txtLeaveContent" runat="server" Width="581px"></dntb:WebEditor>
        </div>
        <div style="height: auto; width: auto">
            <asp:Button ID="btnLeaveWord" Text="确定" runat="server" OnClick="btnLeaveWord_Click" />&nbsp;&nbsp;<asp:Button
                ID="btnReturn" Text="返回" runat="server" /></div>
    </div>
</asp:Content>
