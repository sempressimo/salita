<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHome/CustomerSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Salita_Client.CustomerHome._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <h3>Bienvenido Fulano de Tal</h3>

        <div class="well well-sm">
            Solicite nuestros servicios cortesia de Autogermana:
        </div>

        <div class="container">
            <!-- Example row of columns -->
            <div class="row">
                <div class="col-md-4">
                    <h3><span class="glyphicon glyphicon-glass"></span>&nbsp;<span id="lblRefresment" runat="server"><%=Resources.DefaultResource.CustomerMenuRefreshmentTitle %></span></h3>
                    <p class="small"><%=Resources.DefaultResource.CustomerMenuRefreshmentDesc %></p>
                    <p><a class="btn btn-default" href="#" role="button">Pedir Bebida &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h3><span class="glyphicon glyphicon-road"></span>&nbsp;Transportación</h3>
                    <p class="small">¿Necesita transportación? En esta sección podra solicitar (o cancelar) transporación fuera y/o de regreso al dealer.</p>
                    <p><a class="btn btn-default" href="#" role="button">Solictar Transporte &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h3><span class="glyphicon glyphicon-envelope"></span>&nbsp;Mensajes</h3>
                    <p class="small">En esta sección podrá enviarle mensajes a la dietista, así como ver cualquier mensaje de parte de la dietista o del sistema.</p>
                    <p><a class="btn btn-default" href="#" role="button">Ver Mensajes &raquo;</a></p>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
