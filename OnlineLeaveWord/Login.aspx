<%@ Page Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" Title="登录" %>

<%@ Register Src="UserControls/UC_Login.ascx" TagName="UC_Login" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <uc1:UC_Login ID="UC_Login1" runat="server" />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/48.jpg" OnClick="ImageButton1_Click" />
</asp:Content>

