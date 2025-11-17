<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class=" alert alert-light">ניהול משתמשים</h2>

        <div class="mb-3 w-30">
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="שם משתמש" CssClass="form-control mb-1 " Width="30%"></asp:TextBox>
            <asp:TextBox ID="txtFullName" runat="server" Placeholder="שם מלא" CssClass="form-control mb-1 " Width="30%"></asp:TextBox>
            <asp:TextBox ID="txtRole" runat="server" Placeholder="תפקיד" CssClass="form-control mb-1" Width="30%"></asp:TextBox>
            <asp:CheckBox ID="chkIsActive" runat="server" Text="פעיל" CssClass="form-check-input" />
            <div class="mt-3">
                <asp:Button ID="btnAddUser" runat="server" Text="הוסף משתמש" CssClass="btn btn-primary" OnClick="btnAddUser_Click" />
            </div>
        </div>
        <asp:GridView ID="gvUsers" runat="server"  Width="100%"
            AutoGenerateColumns="False"
            DataKeyNames="UserId"
            OnRowEditing="gvUsers_RowEditing"
            OnRowUpdating="gvUsers_RowUpdating"
            OnRowCancelingEdit="gvUsers_RowCancelingEdit" CellPadding="4" ForeColor="#333333" GridLines="None">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="מזהה" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="שם משתמש" />
                <asp:BoundField DataField="FullName" HeaderText="שם מלא" />
                <asp:BoundField DataField="Role" HeaderText="תפקיד" />

                <asp:CheckBoxField DataField="IsActive" HeaderText="פעיל" />

                <asp:CommandField ShowEditButton="true" EditText="ערוך" CancelText="בטל" UpdateText="שמור" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        <asp:Label runat="server" ID="lblMessage" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
