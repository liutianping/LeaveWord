<%@ Page Language="C#" MasterPageFile="~/Blogs.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="BlogCategoryDelete.aspx.cs" Inherits="Blog_BlogCategoryDelete" Title="删除博客类别" %>

<%@ Register Src="../UserControls/UC_BlogCategoryCollection.ascx" TagName="UC_BlogCollection"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlogContent" Runat="Server">
   <div>
   <h4>类别操作</h4>
           <asp:GridView ID="GridView1" runat="server" Width="80%" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
               <Columns>
                   <asp:TemplateField HeaderText="类别名字">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="更新时间">
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Bind("PublishTime") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField ShowHeader="False">
                       <EditItemTemplate>
                           <asp:Button ID="Button1" runat="server" CommandName="Update"
                               Text="确定" />
                           <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="取消" />
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Button ID="LinkButton2" runat="server" CausesValidation="false" CommandArgument='Eval("id")'
                               CommandName="Edit" Text="编辑" OnClick="LinkButton2_Click"></asp:Button>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
                           <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='Eval("id")'
                               CommandName="Delete" OnClientClick="return confirm('确认删除？？')"
                               Text="删除"></asp:LinkButton>
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
           
           </asp:GridView>





   </div>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPublishTime" Runat="Server">
    类别回收站:<br />
    <div style="text-align:left;"><uc1:UC_BlogCollection ID="UC_BlogCollection1" runat="server" />
        &nbsp;</div>
  
</asp:Content>

