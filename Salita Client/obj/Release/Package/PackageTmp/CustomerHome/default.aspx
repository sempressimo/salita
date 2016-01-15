<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHome/CustomerSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Salita_Client.CustomerHome._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <h3 class="h3">Bienvenido Fulano de Tal</h3>

        <div class="alert alert-info">
            <strong>!Gratis!</strong>&nbsp;Solicite nuestros servicios cortesia de Autogermana
        </div>

        <div class="container">
            <!-- Example row of columns -->
            <div class="row">
                <div class="col-md-4">
                    <h4 class="h4"><span class="glyphicon glyphicon-glass"></span>&nbsp;<span id="lblRefresment" runat="server"><%=Resources.DefaultResource.CustomerMenuRefreshmentTitle %></span></h4>
                    <div style="font-size: 14px;"><%=Resources.DefaultResource.CustomerMenuRefreshmentDesc %></div>
                    <br/>
                    <p><a class="btn btn-primary" href="request_service.aspx" role="button">Pedir Bebida &raquo;</a></p>
                    <br/>
                </div>
                <div class="col-md-4">
                    <h4 class="h4"><span class="glyphicon glyphicon-road"></span>&nbsp;Transportación</h4>
                    <div style="font-size: 14px;">¿Necesita transportación? En esta sección podra solicitar (o cancelar) transporación fuera y/o de regreso al dealer.</div>
                    <br/>
                    <p><a class="btn btn-primary" href="request_transport.aspx" role="button">Solictar Transporte &raquo;</a></p>
                    <br/>
                </div>
                <div class="col-md-4">
                    <h4 class="h4"><span class="glyphicon glyphicon-heart-empty"></span>&nbsp;Estado de Animo</h4>
                    <div style="font-size: 14px;">Dejenos saber su estado de ánimo, haremos lo mejor para que este contento.</div>
                    <br/>
                    <p><a class="btn btn-primary" href="report_mood.aspx" role="button">Informar Animo &raquo;</a></p>
                    <br/>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
