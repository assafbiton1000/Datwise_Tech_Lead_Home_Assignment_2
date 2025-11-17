<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Datwise_Tech_Lead_Home_Assignment.Pages.Events" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Segoe UI; padding: 20px;">
        <h2>דוח אירועים </h2>

        <div class="d-flex w-100 p-3 alert alert-light">
            <asp:Chart ID="Chart1" runat="server" Width="600" Height="400">
                <Series>
                    <asp:Series Name="SalesSeries" ChartType="Column"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>





    </div>
</asp:Content>
