<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 400px; margin: 40px auto; font-family: Segoe UI;">
        <h2 class=" alert alert-light">התחברות למערכת Datwise</h2>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <div class=" w-70 p-3 alert alert-light">
            <div>
                <asp:Label runat="server" Text="Email:" AssociatedControlID="txtEmail" Width="90" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div style="margin-top: 8px;">
                <asp:Label runat="server" Text="Password:" AssociatedControlID="txtPassword" Width="90" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div style="margin-top: 12px;">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-secondary dropdown-toggle" />
                <br />
                <br />
                <br />
                <asp:Label runat="server" Text="" ID="lblError" />
            </div>
        </div>
    </div>
</asp:Content>
