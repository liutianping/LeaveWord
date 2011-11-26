<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <ul>
    </HeaderTemplate>
    <ItemTemplate>
    
     <li> <%# SubString(((OnlineLeaveWord.Model.LeaveWord_M)Container.DataItem).Subject,10)%></li>
    </ItemTemplate>
    <FooterTemplate>
    </ul>
    </FooterTemplate>
    </asp:Repeater>
    

</asp:Content>

