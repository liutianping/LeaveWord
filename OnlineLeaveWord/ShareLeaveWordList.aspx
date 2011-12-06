<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShareLeaveWordList.aspx.cs" Inherits="Index" Title="公共留言板" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="text-align:center;width:600px">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# SubString(((OnlineLeaveWord.Model.LeaveWord_M)Container.DataItem).Subject,7)%>
                    </td>
                    <td style="text-align:left">
                        <%# string.Format("<a href='LeaveWordDeatil.aspx?articleid={0}'>",((OnlineLeaveWord.Model.LeaveWord_M)Container.DataItem).Id)+SubString(((OnlineLeaveWord.Model.LeaveWord_M)Container.DataItem).Content,40)+"</a>"%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <tr style="text-align:left">
            <td>
                <asp:Label ID="lblPageinfo" runat="server" Text="pagesize" />
                <asp:Button ID="btnFirstpage" runat="server" Text="首页" OnClick="btnfirstpage_click" />
                <asp:Button ID="btnPrevious" runat="server" Text="上一页" OnClick="btnprevious_click" />
                <asp:Label ID="lblCurrentpage" runat="server" Text="current" />
                /
                <asp:Label ID="lblTotalPage" runat="server" Text="total" />
                页
                <asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnnext_click" />
                <asp:Button ID="btnLastPage" runat="server" Text="尾页" OnClick="btnlastpage_click" />
            </td>
        </tr>
    </table>
</asp:Content>
