<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Src="UserControls/UC_Login.ascx" TagName="UC_Login" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div><img src="images/login_01.jpg" /></div>
   <uc1:UC_Login ID="UC_Login1" runat="server" />
</asp:Content>

