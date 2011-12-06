<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveWordManager.aspx.cs" Inherits="LeaveWordManager" Title="回复管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="alignCenter">
        <asp:DataList ID="dlLeaveWord" runat="server" CssClass="datalist" >
            <HeaderTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="回复内容"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="回复时间"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="操作"></asp:Label>
                    </td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                    </td>
                      <td>
                        <asp:Button runat="server" ID="btnDelete" CommandArgument='<%# Eval("Id") %>' Text="删 除" OnClick="btnDelete_OnClick" OnClientClick="return confirm(' 确认删除 ?')"/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>
