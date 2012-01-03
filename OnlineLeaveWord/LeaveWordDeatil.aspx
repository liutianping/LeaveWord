<%@ Page Language="C#" MasterPageFile="~/LeaveWord_N.master" AutoEventWireup="true"
    CodeFile="LeaveWordDeatil.aspx.cs" Inherits="LeaveWordDeatil" Title="留言详情" %>

<%@ Register TagPrefix="dntb" Namespace="DotNetTextBox" Assembly="DotNetTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" runat="Server">
    <div style="width: auto; text-align: left">
        <div>
            博客标题：
            <asp:Label runat="server" ID="lblTitle"></asp:Label>
        </div>
        <div>
            回复：
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
        </div>
    </div>
    
    <div id="divCenter">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
    <div id="divBottom">返回顶部</div>
</asp:Content>
