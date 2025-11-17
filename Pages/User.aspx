<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>ניהול משתמשים</h2>

        <asp:GridView ID="gvUsers" runat="server" CssClass="table table-bordered"
            AutoGenerateColumns="False"
            DataKeyNames="UserId"
            OnRowEditing="gvUsers_RowEditing"
            OnRowUpdating="gvUsers_RowUpdating"
            OnRowCancelingEdit="gvUsers_RowCancelingEdit">

            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="מזהה" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="שם משתמש" />
                <asp:BoundField DataField="FullName" HeaderText="שם מלא" />
                <asp:BoundField DataField="Role" HeaderText="תפקיד" />

                <asp:CheckBoxField DataField="IsActive" HeaderText="פעיל" />

                <asp:CommandField ShowEditButton="true" EditText="ערוך" CancelText="בטל" UpdateText="שמור" />
            </Columns>
        </asp:GridView>

        <asp:Label runat="server" ID="lblMessage" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
