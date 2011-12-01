<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveWordDeatil.aspx.cs" Inherits="LeaveWordDeatil" Title="留言详情" %>

<%@ Register TagPrefix="dntb" Namespace="DotNetTextBox" Assembly="DotNetTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 181px">
                留言主题：
            </td>
            <td>
                <asp:Label runat="server" ID="lblTitle" ForeColor="White"></asp:Label>
                <span class="pageViews">
                    <asp:Literal ID="ltPageViews" runat="server"></asp:Literal></span>
            </td>
        </tr>
        <tr>
            <td style="width: 181px">
                留言内容：
            </td>
            <td>
                <asp:Literal ID="lrContent" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td style="width: 181px; vertical-align: top;">
                回复列表:
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="lblStatus" Visible="false"></asp:Label>
                <div id="divScroll" runat="server">
                    <div id="commentHolder">
                        <asp:Repeater runat="server" ID="rpComment" EnableViewState="false">
                            <ItemTemplate>
                                <%# GetContent(Container.DataItem) %>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
        <td style="vertical-align:text-top">
            发表留言:
        </td>
        <td>
                <div style="text-align: center">
                    <div style="width: auto; height: auto; text-align: left">
                        留言主题:<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            Display="Dynamic" ErrorMessage="留言主题为必填"></asp:RequiredFieldValidator></div>
                    <div style="width: auto; height: auto; text-align: left;">
                        留言内容:</div>
                    <div style="width: auto; height: auto; text-align: left;">
                        <dntb:WebEditor ID="txtLeaveContent" runat="server"></dntb:WebEditor>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLeaveContent"
                            Display="Dynamic" ErrorMessage="请输入留言内容"></asp:RequiredFieldValidator></div>
                    <div style="height: auto; width: auto">
                        <asp:Button ID="btnLeaveWord" Text="确定" runat="server" OnClick="btnLeaveWord_Click" />&nbsp;&nbsp;<asp:Button
                            ID="btnReturn" Text="返回" runat="server" /></div>
                </div>
        </td>
        </tr>
    </table>
</asp:Content>
