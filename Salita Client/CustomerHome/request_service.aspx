<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHome/CustomerSite.Master" AutoEventWireup="true" CodeBehind="request_service.aspx.cs" Inherits="Salita_Client.CustomerHome.request_service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form_default" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <div class="page-header">
            <h3><span class="glyphicon glyphicon-road"></span>&nbsp;Servicio de Refrigerio</h3>
        </div>

        <asp:ValidationSummary ID="ValidationSummary1" CssClass="" runat="server" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>



    </div>

</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
