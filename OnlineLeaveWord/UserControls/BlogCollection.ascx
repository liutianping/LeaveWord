<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogCollection.ascx.cs" 
    Inherits="UserControls_BlogCollection" %>
    
     <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div>
            <a href='../Blog/BlogDetail.aspx?blogid=<%# Eval("id") %>'><%# SubString(Eval("blogcontent").ToString())%></a>
           
            <asp:ImageButton runat="server" ID="imgReturn" CommandArgument='<%# Eval("id") %>' ImageUrl="~/images/back.gif" OnClick="ImgReturn_Click"/>
            <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('确认删除？')" runat="server" CommandArgument='<%# Eval("id") %>' ImageUrl="~/images/-.gif" OnClick="ImgDelete_Click"/>
        </div>
    </ItemTemplate>
</asp:Repeater>
