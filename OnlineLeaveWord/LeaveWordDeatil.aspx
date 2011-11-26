<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveWordDeatil.aspx.cs" Inherits="LeaveWordDeatil" Title="留言详情" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<input type="button" value="点这里" onclick="alertWin('标题','这里是内容',300,200);" /> 
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
            <td style="width: 181px;vertical-align:top;">
                回复:
            </td>
            <td>
                <div id="commentHolder">
                    <asp:Repeater runat="server" ID="rpComment" EnableViewState="false">
                        <ItemTemplate>
                            <%# GetContent(Container.DataItem) %>
                        </ItemTemplate>
                        
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
    
    
</asp:Content>
