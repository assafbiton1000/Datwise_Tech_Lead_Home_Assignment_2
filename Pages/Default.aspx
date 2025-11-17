<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard - Datwise</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Segoe UI; padding: 20px;">
        <h2>מסך ראשי</h2>

        <div style="margin-top: 20px;">
            <asp:Panel ID="pnlKPIs" runat="server" CssClass="card shadow-sm p-4 mb-3">
                <div>
                    <asp:Label Font-Bold="true" ID="lblWelcome" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <p></p>
                    <strong>סך רשומות:</strong>
                    <asp:Label ID="lblTotal" runat="server" Text="0" CssClass="mb-2 d-block"></asp:Label>
                </div>
                <div>
                    <strong>סכום כולל:</strong>
                    <asp:Label ID="lblSum" runat="server" Text="0" CssClass="mb-2 d-block"></asp:Label>
                </div>
            </asp:Panel>
        </div>
        <div style="margin-top: 20px;">
            <asp:HyperLink ID="lnkReport" runat="server" NavigateUrl="~/Pages/Report.aspx">עבור לדוח</asp:HyperLink>
        </div>
        <div style="margin-top: 20px;">
            <asp:Button ID="btnLogout" runat="server" Text="התנתק" OnClick="btnLogout_Click" CssClass="btn btn-primary w-20" />
        </div>
    </div>
</asp:Content>
