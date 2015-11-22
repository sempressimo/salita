<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHome/CustomerSite.Master" AutoEventWireup="true" CodeBehind="request_service_feedback.aspx.cs" Inherits="Salita_Client.CustomerHome.request_service_feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="background-color: white !important" class="jumbotron">

        <form runat="server">

            <div class="page-header">
                <h3><span class="glyphicon glyphicon-glass"></span>&nbsp;Refrigerio Confirmado</h3>
            </div>

            <asp:ValidationSummary ID="ValidationSummary1" CssClass="" runat="server" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

            <div>
                El servicio de refrigerio fue confirmado. Estaremos con usted en unos breves instantes.
            </div>

            <br/>
            <br/>

            <div style="direction: rtl;">
                <asp:LinkButton ID="lbOK" CssClass="btn btn-primary" OnClick="lbOK_Click" runat="server">Regresar a Servicios</asp:LinkButton>&nbsp;
            </div>
        
        </form>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
