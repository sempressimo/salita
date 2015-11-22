<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHome/CustomerSite.Master" AutoEventWireup="true" CodeBehind="request_service.aspx.cs" Inherits="Salita_Client.CustomerHome.request_service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form_default" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <div class="page-header">
            <h3><span class="glyphicon glyphicon-glass"></span>&nbsp;Servicio de Refrigerio</h3>
        </div>

        <asp:ValidationSummary ID="ValidationSummary1" CssClass="" runat="server" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <div class="media">
            <div class="media-left">
                <a href="#">
                    <img class="media-object" src="../images/pop_water.png" alt="Water">
                </a>
            </div>
            <div class="media-body">
                <h4 class="media-heading">Botella de Agua</h4>
                <div id="water_alert" class="alert alert-success" runat="server" visible="false">Fue solicitado. Estaremos con usted en unos momentos.</div><div id="Water_Text" runat="server">Disfrute de una botella de agua fría cortesía de Autogermana-BMW.</div><br/>
                <div style="direction: rtl;">
                    <asp:LinkButton ID="lbGetWater" CssClass="btn btn-primary" runat="server" OnClick="lbGetWater_Click">Quiero Agua</asp:LinkButton>
                </div>
            </div>
        </div>

        <hr/>

        <div class="media">
            <div class="media-left">
                <a href="#">
                    <img class="media-object" src="../images/pop_cafe.png" alt="Water">
                </a>
            </div>
            <div class="media-body">
                <h4 class="media-heading">Café</h4>
                Tómese un momento de relax con una tasita de nuestro rico café, cortesía de la casa Autogermana-BMW.<br/>
                <input id="cbMilk" runat="server" type="checkbox" aria-label="..." />&nbsp;Con leche&nbsp;
                <input id="cbSugar" runat="server" type="checkbox" aria-label="..." />&nbsp;Con azúcar&nbsp;
                <input id="cbFakeSugar" runat="server" type="checkbox" aria-label="..." />&nbsp;Con azúcar dieta&nbsp;
                <input id="cbMocachino" runat="server" type="checkbox" aria-label="..." />&nbsp;Con chocolate (mocachino)&nbsp;
                <br/>
                <div style="direction: rtl;">
                    <asp:LinkButton ID="lbGetCoffee" CssClass="btn btn-primary" runat="server">Quiero Café</asp:LinkButton>
                </div>
            </div>
        </div>

        <hr/>

        <div class="media">
            <div class="media-left">
                <a href="#">
                    <img class="media-object" src="../images/pop_soda.png" alt="Water">
                </a>
            </div>
            <div class="media-body">
                <h4 class="media-heading">Refresco</h4>
                Disfrute de un refresco de nuestra variedad para calmar la sed cortesía de Autogermana-BMW.
                <br/>
                    <input id="cbCoke" runat="server" type="radio" aria-label="..." />&nbsp;Coke&nbsp;
                    <input id="cbDietCoke" runat="server" type="radio" aria-label="..." />&nbsp;Diet Coke&nbsp;
                    <input id="cb7UP" runat="server" type="radio" aria-label="..." />&nbsp;7-UP&nbsp;
                <br/>
                <div style="direction: rtl;">
                    <asp:LinkButton ID="lbGetSoda" CssClass="btn btn-primary" runat="server">Quiero Refresco</asp:LinkButton>
                </div>
            </div>
        </div>

    </div>

</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
