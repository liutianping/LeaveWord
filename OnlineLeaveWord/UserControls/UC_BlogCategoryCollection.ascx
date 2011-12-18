<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_BlogCategoryCollection.ascx.cs" 
    Inherits="UserControls_UC_BlogCollection" %>
<div style="float: left;">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div>
                <div style="text-align: right">
                    <a href='BlogListByCategoryID.aspx?ctegoryid=<%# Eval("id") %>'>
                        <%# Eval("categoryname")%>(<%# GetBlogCountByCategoryID(Eval("id"))%>)
                    </a>
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="return confirm('确认删除？注意：从回收站删除将不能恢复。')" ImageUrl="~/images/-.gif" OnClick="ImgButton_Click"
                        CommandArgument='<%# Eval("id") %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
