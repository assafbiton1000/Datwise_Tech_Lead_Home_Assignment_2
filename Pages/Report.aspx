<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div style="padding: 20px; font-family: Segoe UI;" class="w-100">
        <h2 class=" alert alert-light">דוח נתונים</h2>

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

        <div style="margin-bottom: 10px;" class="w-100">
            קטגוריה:
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FilterChanged" CssClass="btn btn-secondary dropdown-toggle">
                <asp:ListItem Value="">All</asp:ListItem>
            </asp:DropDownList>

            אזור:
            <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FilterChanged" CssClass="btn btn-secondary dropdown-toggle">
                <asp:ListItem Value="">All</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnRefresh" runat="server" Text="רענן" OnClick="FilterChanged" CssClass="btn btn-primary w-20" />
            <asp:Button ID="btnExportCsv" runat="server" Text="ייצוא לאקסל" OnClick="btnExportCsv_Click" CssClass="btn btn-primary w-20" />
        </div>
        <div class="row  w-90  alert alert-light mr-3">
            <asp:GridView Top="0%" Width="100%" ID="gvReport" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                OnPageIndexChanging="gvReport_PageIndexChanging" AllowSorting="True" OnSorting="gvReport_Sorting" CellPadding="4" ForeColor="#333333" GridLines="None"
                PagerSettings-Mode="NumericFirstLast"
                PagerSettings-Position="Bottom"
                PagerStyle-BackColor="#2461BF"
                PagerStyle-ForeColor="White"
                PagerStyle-HorizontalAlign="Center">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="ValueAmount" HeaderText="Value" DataFormatString="{0:N2}" SortExpression="ValueAmount" />
                    <asp:BoundField DataField="EventDate" HeaderText="EventDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="EventDate" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>

    </div>


</asp:Content>
