<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_BlogListByPublishTime.ascx.cs"
    Inherits="UserControls_UC_BlogListByPublishTime" %>
<div style="float: left;">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div>
                <div style="text-align: right">
                    <a href='../Blog/BlogListByPublishTime.aspx?publishtime=<%# GetContent(Container.DataItem) %>'>
                    <%# Eval("year") %>年<%# Eval("month") %>月
                       </a>
                        
                        
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
