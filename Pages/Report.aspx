<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div style="padding: 20px; font-family: Segoe UI;">
        <h2>דוח נתונים</h2>

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

        <div style="margin-bottom: 10px;">
            קטגוריה:
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FilterChanged">
                <asp:ListItem Value="">All</asp:ListItem>
            </asp:DropDownList>

            אזור:
            <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FilterChanged">
                <asp:ListItem Value="">All</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnRefresh" runat="server" Text="רענן" OnClick="FilterChanged" />
            <asp:Button ID="btnExportCsv" runat="server" Text="Export CSV" OnClick="btnExportCsv_Click" />
        </div>
        <div class="row">
            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20"
                OnPageIndexChanging="gvReport_PageIndexChanging" AllowSorting="true" OnSorting="gvReport_Sorting" CssClass="table table-striped table-bordered table-condensed table-hover" BorderColor="#336699">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="ValueAmount" HeaderText="Value" DataFormatString="{0:N2}" SortExpression="ValueAmount" />
                    <asp:BoundField DataField="EventDate" HeaderText="EventDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="EventDate" />
                </Columns>
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#0066FF" />
            </asp:GridView>
        </div>

    </div>


</asp:Content>
