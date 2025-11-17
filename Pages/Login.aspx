<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 400px; margin: 40px auto; font-family: Segoe UI;">
        <h2>התחברות למערכת Datwise</h2>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <div>
            <asp:Label runat="server" Text="Email:" AssociatedControlID="txtEmail" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div style="margin-top: 8px;">
            <asp:Label runat="server" Text="Password:" AssociatedControlID="txtPassword" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div style="margin-top: 12px;">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <br />
            <br />
            <asp:Label runat="server" Text="" ID="lblError" />
        </div>
    </div>
</asp:Content>
